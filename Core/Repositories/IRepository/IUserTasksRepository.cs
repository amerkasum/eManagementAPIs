using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IUserTasksRepository : IRepository<UserTasks>
    {
        UserTasks GetByUserIdAndTaskId(int userId, int taskId);
    }
}
