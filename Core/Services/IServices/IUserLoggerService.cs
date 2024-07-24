using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.IServices
{
    public interface IUserLoggerService
    {
        UserLogger CreateUserLog(int userId);
        string EncodePasswordToBase64(string password);
        string DecodeFrom64(string encodedData);
    }
}
