using EmailWorkerService.Utils;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Mail;
using System.Net;

namespace EmailWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
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

            channel.QueueDeclare(queue: "email-send", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, e) =>
            {
                var body = e.Body;
                var json = System.Text.Encoding.UTF8.GetString(body.ToArray());
                var email = System.Text.Json.JsonSerializer.Deserialize<Email>(json);

                SendEmailAsync(email.EmailTo, email.Subject, email.Body);
            };

            channel.BasicConsume("email-send", true, consumer);
        }

        public Task SendEmailAsync(string emailTo, string subject, string message)
        {
            var emailFrom = "kasumamer@gmail.com";
            var password = "wlqt yqvo cwhn ujsv";

            var client = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(emailFrom, password),
                UseDefaultCredentials = false,
                Port = 587
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailFrom),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(emailTo);

            client.SendMailAsync(mailMessage);

            return Task.CompletedTask;
        }
    }
}
