using MassTransit;
using MongoDB.Driver;
using Shared;
using Stock.API.Consumers;
using Stock.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services, uygulama servisini yapılandırmak için kullanılır
builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<OrderCreatedEventConsumer>();
    // MassTransit'in RabbitMQ kullanarak yapılandırılması
    configurator.UsingRabbitMq((context, _configurator) =>
    {
        // RabbitMQ'ya bağlantı kurulacak host adresi, appsettings.json dosyasından veya başka bir yapılandırma kaynağından alınır
        _configurator.Host(builder.Configuration["RabbitMQ"]);
        _configurator.ReceiveEndpoint(RabbitMQSettings.Stock_OrderCreatedEventQueue, e => e.ConfigureConsumer<OrderCreatedEventConsumer>(context));
    });
});

builder.Services.AddSingleton<MongoDBService>();

#region Harici - MongoDB Fake Data eklemek için
using var scope = builder.Services.BuildServiceProvider().CreateScope();
var mongoDBService = scope.ServiceProvider.GetService<MongoDBService>();
var collection = mongoDBService.GetCollection<Stock.API.Models.Entities.Stock>();

if (!collection.FindSync(x => true).Any())
{
    await collection.InsertOneAsync(new(){ProductId = Guid.Parse("0892d505-d653-4adc-b350-e71a84e65c4a"), Count = 200});
    await collection.InsertOneAsync(new(){ProductId = Guid.Parse("79426580-403f-4263-8b76-028d4e56f508"), Count = 300});
    await collection.InsertOneAsync(new(){ProductId = Guid.Parse("1886f2ed-aea6-4123-a596-d1fa3a1e4aea"), Count = 400});
    await collection.InsertOneAsync(new(){ProductId = Guid.Parse("a4655fdc-5dd5-4949-bcaa-806fef8c6f25"), Count = 500});
}
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
