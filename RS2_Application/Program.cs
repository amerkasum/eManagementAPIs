using Core.DatabaseContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RS2_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider
                    .GetRequiredService<ApplicationDbContext>();

                int maxRetries = 5;
                int retries = 0;

                while (retries < maxRetries)
                {
                    try
                    {
                        service.Database.Migrate();

                        Console.WriteLine("Database migration completed successfully.");
                        break;
                    }
                    catch (SqlException ex)
                    {
                        retries++;

                        Console.WriteLine(
                            $"Database migration failed ({retries}/{maxRetries})."
                        );

                        if (retries >= maxRetries)
                        {
                            Console.WriteLine(
                                "Maximum number of migration retries reached."
                            );

                            throw;
                        }

                        Thread.Sleep(5000);
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
