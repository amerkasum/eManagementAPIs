using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.Repository
{
    public class TaskStatusesRepository : Repository<TaskStatuses>, ITaskStatusesRepository
    {
        public TaskStatusesRepository(ApplicationDbContext context) : base(context) { }
    }
}
