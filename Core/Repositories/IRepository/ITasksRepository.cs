using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface ITasksRepository : IRepository<Tasks>
    {
        List<TasksDto> GetAllTasks();
    }
}
