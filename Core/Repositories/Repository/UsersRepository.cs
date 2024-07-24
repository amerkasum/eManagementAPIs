using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Repository
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public UsersRepository(MyContext context) : base(context)
        {
        }

        public Users GetByFirstName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.FirstName.Equals(name));
        }

        public Users GetByLastName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.LastName.Equals(name));
        }

        public bool DoesEmailAlreadyExist(string email)
        {
            return _context.Users.Where(x => !x.IsDeleted && x.IsActive).Any(x => x.Email == email);
        }

        public Users GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}
