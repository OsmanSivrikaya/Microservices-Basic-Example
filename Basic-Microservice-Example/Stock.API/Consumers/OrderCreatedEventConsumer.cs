using MassTransit;
using MongoDB.Driver;
using Shared;
using Shared.Events;
using Stock.API.Services;

namespace Stock.API.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
    {
        IMongoCollection<Models.Entities.Stock> _stockCollection;
        readonly ISendEndpointProvider _sendEndpointProvider;
        readonly IPublishEndpoint _publishEndpoint;
        public OrderCreatedEventConsumer(MongoDBService mongoDBService, ISendEndpointProvider sendEndpointProvider, IPublishEndpoint publishEndpoint)
        {
            _stockCollection = mongoDBService.GetCollection<Models.Entities.Stock>();
            _sendEndpointProvider = sendEndpointProvider;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            List<bool> stockResult = new();
            foreach (var orderItem in context.Message.OrderItems)
            {
                stockResult.Add((await _stockCollection.FindAsync(x => x.ProductId == orderItem.ProductId && x.Count >= orderItem.Count)).Any());
            }

            if (stockResult.TrueForAll(x => x.Equals(true)))
            {
                // gerekli sipariş işlemleri burda yapılıcak
                foreach (var orderItem in context.Message.OrderItems)
                {
                    var stock = await (await _stockCollection.FindAsync(x => x.ProductId == orderItem.ProductId)).FirstOrDefaultAsync();
                    stock.Count -= orderItem.Count;
                    await _stockCollection.FindOneAndReplaceAsync(x => x.ProductId == orderItem.ProductId, stock);
                }

                // payment servise'e stok işlemlerinin tamamlandığına dair ödeme işlemlerini başlatması için event gönderiyoruz

                StockReservedEvent stockReservedEvent = new()
                {
                    BuyerId = context.Message.BuyerId,
                    OrderId = context.Message.OrderId,
                    TotalPrice = context.Message.TotalPrice
                };
                var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue: {RabbitMQSettings.Payment_StockReservedEventQueue}"));
                await sendEndpoint.Send(stockReservedEvent);
                await Console.Out.WriteLineAsync("Stok İşlemeleri Başarılı");
            }
            else
            {
                // sipariş durumu geçersiz olduğuna dair işlemler
                StockNotReservedEvent stockNotReservedEvent = new()
                {
                    BuyerId = context.Message.BuyerId,
                    OrderId = context.Message.OrderId,
                    Message = "Hatalı işlem"
                };
                await _publishEndpoint.Publish(stockNotReservedEvent);
                await Console.Out.WriteLineAsync("Stok İşlemeleri Başarısız");
            }

            //return Task.CompletedTask;
        }
    }
}