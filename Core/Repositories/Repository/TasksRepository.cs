using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class TasksRepository : Repository<Tasks>, ITasksRepository
    {
        public TasksRepository(ApplicationDbContext context) : base(context) { }

        public List<TasksDto> GetTasksByUserId(int? userId)
        {

            var taskIds = _context.UserTasks.Where(x => x.UserId == userId || userId == null).Select(x => x.TaskId).ToList();
            var userTasks = _context.UserTasks.Where(x => taskIds.Contains(x.TaskId)).ToList();

            List<TasksDto> results = _context.Tasks.Where(x => taskIds.Contains(x.Id)).Select(x => new TasksDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                StatusCode = x.StatusCode,
                DueDate = x.DueDate,
                Priority = x.Priority,
            }).ToList();

            results.ForEach(x =>
            {
                x.UserIds = userTasks.Where(y => y.TaskId == x.Id).Select(y => y.UserId).ToList();
            });

            return results;
        }

        public List<TasksDto> GetTasksByStatusCode(int? statusCode)
        {

            var taskIds = _context.UserTasks.Select(x => x.TaskId).ToList();
            var userTasks = _context.UserTasks.Where(x => taskIds.Contains(x.TaskId)).ToList();

            List<TasksDto> results = _context.Tasks.Where(x => taskIds.Contains(x.Id) && (x.StatusCode == statusCode || statusCode == null)).Select(x => new TasksDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                StatusCode = x.StatusCode,
                DueDate = x.DueDate,
                Priority = x.Priority,
            }).ToList();

            results.ForEach(x =>
            {
                x.UserIds = userTasks.Where(y => y.TaskId == x.Id).Select(y => y.UserId).ToList();
            });

            return results;
        }


    }
}
