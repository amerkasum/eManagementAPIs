using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class UserRolesRepository : Repository<UserRoles>, IUserRolesRepository
    {
        public UserRolesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public UserRoles GetByUserId(int userId)
        {
            return _context.UserRoles.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
