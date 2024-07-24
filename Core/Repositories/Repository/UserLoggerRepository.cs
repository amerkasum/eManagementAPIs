using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class UserLoggerRepository : Repository<UserLogger>, IUserLoggerRepository
    {
        public UserLoggerRepository(MyContext context) : base(context)
        {
        }

        public UserLoggerDto GetByUserId(int userId)
        {
            var userLogger = _context.UserLogger.OrderByDescending(x => x.CreatedDateTime).FirstOrDefault(x => x.UserId == userId);

            UserLoggerDto result = null;

            if (userLogger != null)
            {
                result = new UserLoggerDto
                {
                    Id = userLogger.Id,
                    UserId = userLogger.UserId,
                    AccessCode = userLogger.AccessCode,
                    AccessType = userLogger.AccessType,
                    IpAddress = userLogger.IpAddress
                };
            }
            
            return result;
        }
    }
}
