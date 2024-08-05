using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.Repository
{
    public class UserResidenceRepository : Repository<UserResidence>, IUserResidenceRepository
    {
        public UserResidenceRepository(MyContext context) : base (context) { }

    }
}
