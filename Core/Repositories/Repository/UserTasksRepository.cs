using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.Repository
{
    public class UserTasksRepository : Repository<UserTasks>, IUserTasksRepository
    {
        public UserTasksRepository(ApplicationDbContext context) : base(context){ }
    }
}
