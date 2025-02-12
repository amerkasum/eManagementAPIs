using Core.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using EasyNetQ;
using Models.Entities.Email;

namespace Core.Services.Services
{
    public class EmailServiceClient : IEmailServiceClient
    {
        private readonly IHttpClientFactory HttpClientFactory;
        public readonly IConfiguration Configuration;
        private readonly IBus Bus;

        public EmailServiceClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.HttpClientFactory = httpClientFactory;
            this.Configuration = configuration;

            var rabbitMQHost = configuration["RABBITMQ_HOST"] ?? "localhost";
            var rabbitMQUsername = configuration["RABBITMQ_USERNAME"] ?? "guest";
            var rabbitMQPassword = configuration["RABBITMQ_PASSWORD"] ?? "guest";
            var rabbitMQVirtualHost = configuration["RABBITMQ_VIRTUALHOST"] ?? "/";

            var rabbitMQConnectionString = $"host={rabbitMQHost};username={rabbitMQUsername};password={rabbitMQPassword};virtualHost={rabbitMQVirtualHost}";

            this.Bus = RabbitHutch.CreateBus(rabbitMQConnectionString);
        }

        public async Task SendEmailAsync(string emailTo, string subject, string message)
        {
            var httpClient = HttpClientFactory.CreateClient();

            var emailRequest = new
            {
                EmailTo = emailTo,
                Subject = subject,
                Message = message
            };

            var content = new StringContent(JsonConvert.SerializeObject(emailRequest), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"https://localhost:5002/send-email", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to send email.");
            }
        }

        public void PublishEmail(Email emailMessage)
        {
            var factory = new ConnectionFactory()
            {
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rs2app-rabbitmq",
                UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
                Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest",
                VirtualHost = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST") ?? "/"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare("email-box", ExchangeType.Direct);
            channel.QueueDeclare("email-send", false, false, false);
            channel.QueueBind("email-send","email-box", "email-add");

            var json = System.Text.Json.JsonSerializer.Serialize(emailMessage);
            var body = System.Text.Encoding.UTF8.GetBytes(json);

            channel.BasicPublish("email-box", "email-add", null, body);
            //Console.WriteLine($"Received email message for {emailMessage.EmailTo}. Subject: {emailMessage.Subject}");
            //Bus.PubSub.Publish(emailMessage, "email-queue");
        }




    }
}
