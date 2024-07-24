using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.Repository
{
    public class UserRolesRepository : Repository<UserRoles>, IUserRolesRepository
    {
        public UserRolesRepository(MyContext context) : base(context)
        {
        }
    }
}
