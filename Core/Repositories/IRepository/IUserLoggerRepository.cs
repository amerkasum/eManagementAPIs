using Core.Repositories.Repository;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IUserLoggerRepository : IRepository<UserLogger>
    {
        UserLoggerDto GetByUserId(int userId);
    }
}
