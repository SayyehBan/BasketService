using BasketService.Infrastructure.Contexts;
using BasketService.Infrastructure.MappingProfile;
using BasketService.MessageingBus.ReceivedMessages.ProductMessages;
using BasketService.Model.Services.BasketServices;
using BasketService.Model.Services.DiscountServices;
using BasketService.Model.Services.ProductServices;
using Microsoft.EntityFrameworkCore;
using SayyehBanTools.ConfigureService;
using SayyehBanTools.ConnectionDB;
using SayyehBanTools.MessagingBus.RabbitMQ.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BasketDataBaseContext>(p => p.UseSqlServer(SqlServerConnection.ConnectionString("R3hqmv70CrzGD9McXmmdOg==", "qVj0t1nCGZdaF6ktSQydaQ==", "Fx1DLG7aIQ9DyBk2gdNpUw==", "3xaGPOSYEg7nv5N5r3yCjA==", "5u28ligne404216t", "9fd51b5b16374u0e")),ServiceLifetime.Singleton);
builder.Services.AddTransient<IBasketService, RBasketService>();
builder.Services.AddTransient<IDiscountService, RDiscountService>();
builder.Services.AddTransient<IProductService, RProductService>();
//RabbitMQ
builder.Services.Configure<RabbitMqConnectionSettings>(builder.Configuration
    .GetSection("RabbitMq"));
//builder.Services.AddScoped<IMessageBus, RabbitMQMessageBus>();
//پیکربندی های پیش فرض SayyehbanTools
var configureServices = new ConfigureServicesRabbitMQ();
configureServices.ConfigureService(builder.Services);
builder.Services.AddHostedService<ReceivedUpdateProductNameMessage>();
//mapper
builder.Services.AddAutoMapper(typeof(BasketMappingProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
