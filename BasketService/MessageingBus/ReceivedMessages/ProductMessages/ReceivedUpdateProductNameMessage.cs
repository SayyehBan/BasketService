using BasketService.Model.Links;
using BasketService.Model.Services.ProductServices;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SayyehBanTools.MessagingBus.RabbitMQ.Connection;
using SayyehBanTools.MessagingBus.RabbitMQ.Model;
using System.Text;

namespace BasketService.MessageingBus.ReceivedMessages.ProductMessages;

public class ReceivedUpdateProductNameMessage : BackgroundService
{
    private readonly RabbitMQConnection rabbitMQConnection;
    private readonly IProductService productService;
    public ReceivedUpdateProductNameMessage(RabbitMQConnection rabbitMQConnection, IProductService productService)
    {
        this.rabbitMQConnection = rabbitMQConnection;
        this.rabbitMQConnection.CreateRabbitMQConnection();
        this.rabbitMQConnection.Channel = rabbitMQConnection.Connection.CreateModel();
        this.productService = productService;
        this.rabbitMQConnection.Channel.QueueDeclare(queue: RabbitMQLink.UpdateProductName, durable: true,
            exclusive: false, autoDelete: false, arguments: null);
        this.rabbitMQConnection.Channel.ExchangeDeclare(RabbitMQLink.UpdateProductName, ExchangeType.Fanout, true, false);
        this.rabbitMQConnection.Channel.QueueDeclare(RabbitMQLink.Basket_GetMessageOnUpdateProductName, true, false, false);
        this.rabbitMQConnection.Channel.QueueBind(RabbitMQLink.Basket_GetMessageOnUpdateProductName, RabbitMQLink.UpdateProductName, "");
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(rabbitMQConnection.Channel);
        consumer.Received += (ch, ea) =>
        {
            var content = Encoding.UTF8.GetString(ea.Body.ToArray());
            var updateCustomerFullNameModel = JsonConvert.DeserializeObject<UpdateProductNameMessage>(content);

            var resultHandeleMessage = HandleMessage(updateCustomerFullNameModel);
            if (resultHandeleMessage)
                rabbitMQConnection.Channel.BasicAck(ea.DeliveryTag, false);
        };

        rabbitMQConnection.Channel.BasicConsume(RabbitMQLink.Basket_GetMessageOnUpdateProductName, false, consumer);
        return Task.CompletedTask;
    }


    private bool HandleMessage(UpdateProductNameMessage updateProduct)
    {
        return productService.UpdateProductName(updateProduct.Id, updateProduct.NewName);
    }
}
public class UpdateProductNameMessage
{
    public Guid Id { get; set; }
    public string NewName { get; set; }
}