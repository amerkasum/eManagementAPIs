using Core.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Services
{
    public class EmailServiceClient : IEmailServiceClient
    {
        private readonly IHttpClientFactory HttpClientFactory;
        public readonly IConfiguration Configuration;

        public EmailServiceClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.HttpClientFactory = httpClientFactory;
            this.Configuration = configuration;
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




    }
}
