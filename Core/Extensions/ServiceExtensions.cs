using Core.Services.EmailService.EmailService;
using Core.Services.EmailService.IEmailService;
using Core.Services.HelperServices.HelperService;
using Core.Services.HelperServices.IHelperService;
using Core.Services.IServices;
using Core.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IUserLoggerService, UserLoggerService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IWorkingAbsenceService, WorkingAbsenceService>();
            services.AddTransient<IWorkingDaysService, WorkingDaysService>();
            services.AddTransient<IHelperService, HelperService>();
            services.AddTransient<IUserService, UserService>();

        }
    }
}
