using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.API.Models;
using Shared.Events;

namespace Order.API.Consumers
{
    public class PaymentCompletedEventConsumer : IConsumer<PaymentCompletedEvent>
    {
        readonly OrderAPIDbContext _orderAPIDbContext;

        public PaymentCompletedEventConsumer(OrderAPIDbContext orderAPIDbContext)
        {
            _orderAPIDbContext = orderAPIDbContext;
        }

        public async Task Consume(ConsumeContext<PaymentCompletedEvent> context)
        {
           var order = await _orderAPIDbContext.Orders.FirstOrDefaultAsync(x=>x.OrderId == context.Message.OrderId);
           order.OrderStatu = Models.Enums.OrderStatus.Completed;
           await _orderAPIDbContext.SaveChangesAsync();
        }
    }
}