using Core.DatabaseContext;
using Models.Entities;
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
    }
}
