using Models.Entities.Dtos;
using RS2_Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.IServices
{
    public interface IUserService
    {
        void HandleUserData(int userId, UsersViewModel model);
    }
}
