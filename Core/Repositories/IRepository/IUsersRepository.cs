using Core.DatabaseContext;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.Dtos.Desktop;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IUsersRepository : IRepository<Users>
    {
        Users GetByFirstName(string name);
        Users GetByLastName(string name);
        bool DoesEmailAlreadyExist(string email);
        Users GetByEmail(string email);
        IEnumerable<UsersDto> GetUsers(string fullName);
        UserProfileDto GetUserProfileDtoByUserId(int userId);
        List<UsersDesktopDto> GetUsersDesktop();
        List<SelectListHelper> GetSelectLists();
        Users GetByUsername(string username);
    }
}
