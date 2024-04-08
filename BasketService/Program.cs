using BasketService.Infrastructure.Contexts;
using BasketService.Infrastructure.MappingProfile;
using BasketService.Model.Services.BasketServices;
using BasketService.Model.Services.DiscountServices;
using Microsoft.EntityFrameworkCore;
using SayyehBanTools.ConnectionDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BasketDataBaseContext>(p => p.UseSqlServer(SqlServerConnection.ConnectionString("R3hqmv70CrzGD9McXmmdOg==", "qVj0t1nCGZdaF6ktSQydaQ==", "Fx1DLG7aIQ9DyBk2gdNpUw==", "3xaGPOSYEg7nv5N5r3yCjA==", "5u28ligne404216t", "9fd51b5b16374u0e")));
builder.Services.AddTransient<IBasketService, RBasketService>();
builder.Services.AddTransient<IDiscountService, RDiscountService>();
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
