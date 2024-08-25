using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class UserTasksRepository : Repository<UserTasks>, IUserTasksRepository
    {
        public UserTasksRepository(ApplicationDbContext context) : base(context){ }

        public UserTasks GetByUserIdAndTaskId(int userId, int taskId)
        {
            return _context.UserTasks.FirstOrDefault(x => x.UserId == userId && x.TaskId == taskId);
        }
    }
}
