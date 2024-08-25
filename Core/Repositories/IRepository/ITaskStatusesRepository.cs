using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface ITaskStatusesRepository : IRepository<TaskStatuses>
    {
        TaskStatuses GetByName(string name);
    }
}
