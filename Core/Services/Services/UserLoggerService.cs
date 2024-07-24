using Core.Services.EmailService.IEmailService;
using Core.Services.IServices;
using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Services.Services
{
    public class UserLoggerService : IUserLoggerService
    {
        private readonly IUnitOfWork DataUnitOfWork;
        private readonly IHttpContextAccessor ContextAccessor;
        private readonly IEmailSender EmailSender;
        public UserLoggerService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, IEmailSender emailSender)
        {
            this.DataUnitOfWork = unitOfWork;
            this.ContextAccessor = contextAccessor;
            this.EmailSender = emailSender;
        }

        public UserLogger CreateUserLog(int userId)
        {
            var user = DataUnitOfWork.UsersRepository.GetById(userId);

            string ipAddress = ContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
            bool isLocal = false;

            if (ipAddress == "::1")
            {
                ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                isLocal = true;
            }

            Random generator = new Random();
            string code = generator.Next(0, 1000000).ToString("D6");

            var lastUserLog = DataUnitOfWork.UserLoggerRepository.GetByUserId(userId);

            bool sendEmail = false;
            if (lastUserLog != null)
            {
                sendEmail = lastUserLog.IpAddress != ipAddress;

                if (sendEmail)
                {
                    var subject = "Security message";
                    var message = $"Someone is trying to sign in to your account from {ipAddress}.\n We want to make sure that this is you, here is your access code:\n {code}";
                    EmailSender.SendEmailAsync(user.Email, subject, message);
                }
            }

            UserLogger userLogger = new UserLogger
            {
                IpAddress = ipAddress,
                AccessType = !isLocal ? nameof(Enumerations.AccessType.PRODUCTION) : nameof(Enumerations.AccessType.DEVELOPMENT),
                AccessCode = code,
                UserId = userId,
                IsAccessCodeSent = sendEmail,
            };

            DataUnitOfWork.UserLoggerRepository.Add(userLogger);
            DataUnitOfWork.Complete();

            return userLogger;
        }


        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw ex; ;
            }
        }

        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
