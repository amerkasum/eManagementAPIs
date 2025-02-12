using EasyNetQ;
using EmailMicroserviceMinimalAPI.Utils;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.EmailService.EmailService
{
    public class EmailSender : BackgroundService
    {

        private readonly string Host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost";
        private readonly string Username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
        private readonly string Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
        private readonly string VirtualHost = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST") ?? "/";

        public EmailSender()
        {

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


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    try
            //    {
            //        //using (var bus = RabbitHutch.CreateBus($"host={Host};virtualHost={VirtualHost};username={Username};password={Password}"))
            //        //{
            //        //    bus.PubSub.Subscribe<Email>("email-queue", emailMessage =>
            //        //    {
            //        //        Console.WriteLine("Received an email message, sending email...");
            //        //        SendEmailAsync(emailMessage.EmailTo, emailMessage.Subject, emailMessage.Body);
            //        //    });
            //        //    Console.WriteLine("Listening for email messages...");
            //        //    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            //        //}


            //    }
            //    catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            //    {
            //        break;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}

            using (var bus = RabbitHutch.CreateBus($"host={Host};virtualHost={VirtualHost};username={Username};password={Password}"))
            {
                Console.WriteLine("Bus created successfully.");
                bus.PubSub.Subscribe<Email>("email-queue", emailMessage =>
                {
                    Console.WriteLine("Received an email message, sending email...");
                    SendEmailAsync(emailMessage.EmailTo, emailMessage.Subject, emailMessage.Body);
                });
            }

        }


    }
}