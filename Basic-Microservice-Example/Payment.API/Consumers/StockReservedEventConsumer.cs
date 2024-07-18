using MassTransit;
using Shared.Events;

namespace Payment.API.Consumers
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        readonly IPublishEndpoint _publishEndpoint;

        public StockReservedEventConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            //   ödeme işlemleri
            if (true)
            {
                // ödeme işlemleri başarılı ise
                PaymentCompletedEvent paymentCompletedEvent = new(){
                    OrderId = context.Message.OrderId
                };
                _publishEndpoint.Publish(paymentCompletedEvent);

                Console.WriteLine("Ödeme Başarılı");
            }
            else
            {
                // ödeme işleminde sıkıntı olduğunda
                PaymentFailedEvent paymentFailedEvent = new(){
                    OrderId = context.Message.OrderId,
                    Message = "Hata Oluştu"
                };
                _publishEndpoint.Publish(paymentFailedEvent);

                Console.WriteLine("Ödeme Başarısız");
            }
            return Task.CompletedTask;
        }
    }
}