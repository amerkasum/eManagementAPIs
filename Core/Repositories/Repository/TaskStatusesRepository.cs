using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class TaskStatusesRepository : Repository<TaskStatuses>, ITaskStatusesRepository
    {
        public TaskStatusesRepository(ApplicationDbContext context) : base(context) { }

        public TaskStatuses GetByName(string name)
        {
            return _context.TaskStatuses.FirstOrDefault(x => name.ToLower().Equals(x.Name.ToLower()));
        }
    }
}
