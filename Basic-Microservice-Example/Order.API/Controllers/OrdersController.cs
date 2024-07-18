using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Order.API.Models;
using Order.API.Models.Entities;
using Order.API.Models.ViewModels; 
using Shared.Events; 
using Shared.Messages; 

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(OrderAPIDbContext context, IPublishEndpoint publishEndpoint) : ControllerBase
    {

        [HttpPost] // HTTP POST isteği ile erişilir
        public async Task<IActionResult> CreateOrder(CreateOrderVM createOrder)
        {
            // Yeni bir sipariş oluşturur
            Models.Entities.Order order = new()
            {
                OrderId = Guid.NewGuid(), // Yeni bir benzersiz kimlik oluşturur
                BuyerId = createOrder.BuyerId, // Alıcı kimliğini ayarlar
                CreatedDate = DateTime.Now, // Siparişin oluşturulma tarihini ayarlar
                OrderStatu = Models.Enums.OrderStatus.Suspend // Sipariş durumunu "Suspend" olarak ayarlar
            };

            // Sipariş kalemlerini ekler
            order.OrderItems = createOrder.OrderItems.Select(x => new OrderItem
            {
                Count = x.Count, // Ürün sayısını ayarlar
                Price = x.Price, // Ürün fiyatını ayarlar
                ProductId = x.ProductId // Ürün kimliğini ayarlar
            }).ToList();

            // Toplam fiyatı hesaplar
            order.TotalPrice = createOrder.OrderItems.Sum(x => (x.Price * x.Count));

            // Siparişi veritabanına ekler
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            // Sipariş oluşturulduğunda event oluşturur
            OrderCreatedEvent orderCreatedEvent = new(){
                BuyerId = order.BuyerId, // Alıcı kimliğini ayarlar
                OrderId = order.OrderId, // Sipariş kimliğini ayarlar
                OrderItems = order.OrderItems.Select(x => new OrderItemMessage{
                    Count = x.Count, // Ürün sayısını ayarlar
                    ProductId = x.ProductId // Ürün kimliğini ayarlar
                }).ToList(),
                TotalPrice = order.TotalPrice
            };

            // Event'i publish eder Publish kuyruğu dinleyen herkese göderir veriyi
            await publishEndpoint.Publish(orderCreatedEvent);

            // HTTP 200 OK yanıtı döner
            return Ok();
        }
    }
}
