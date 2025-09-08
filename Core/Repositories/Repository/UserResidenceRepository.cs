using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class UserResidenceRepository : Repository<UserResidence>, IUserResidenceRepository
    {
        public UserResidenceRepository(ApplicationDbContext context) : base (context) { }

        public UserResidence GetByUserId(int userId)
        {
            return _context.UserResidence.FirstOrDefault(x => x.UserId == userId);
        }

    }
}
