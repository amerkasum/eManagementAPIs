using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Helpers.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
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

        public List<TasksDto> GetAllTasks()
        {

            var taskIds = _context.UserTasks.Select(x => x.TaskId).ToList();
            var userTasks = _context.UserTasks.Include(x => x.User)
                .Where(x => taskIds.Contains(x.TaskId))
                .ToList();

            var userTaskSummary = userTasks
                .GroupBy(x => x.TaskId)
                .Select(g => new
                {
                    TaskId = g.Key,
                    UsersAssigned = g.Count() > 1
                        ? g.FirstOrDefault().User.FullName + " and " + (g.Count() - 1).ToString() + " others"
                        : g.FirstOrDefault().User.FullName
                })
                .ToDictionary(x => x.TaskId, x => x.UsersAssigned);

            var results = _context.Tasks
                .Include(x => x.City)
                .ThenInclude(x => x.Country)
                .Select(x => new TasksDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    StatusCode = x.StatusCode,
                    Priority = x.Priority,
                    Location = x.City.Name + ", " + x.City.Country.Iso,
                    UsersAssigned = userTaskSummary.ContainsKey(x.Id)
                        ? userTaskSummary[x.Id]
                        : string.Empty
                })
                .ToList();

            return results;
        }

        public TaskDetailsDto GetTaskDetails(int taskId, int userId)
        {
            var userIds = _context.UserTasks.Include(x => x.User)
                .Where(x => taskId == x.TaskId).Select(x => x.UserId).ToList();

            var users = _context.UserPositions.Include(x => x.User).Include(x => x.Position).Where(x => userIds.Contains(x.UserId)).ToList();

            var userTask = _context.UserTasks.FirstOrDefault(x => x.UserId == userId && x.TaskId == taskId);
            bool allowReview = true;
            if(userTask != null)
            {
                allowReview = _context.TaskReviews.Where(x => x.UserTaskId == userTask.Id).Any() ? false : true;
            }


            List<UserPositionBasicDto> usersDto = new List<UserPositionBasicDto>();
            users.ForEach(x =>
            {
                UserPositionBasicDto userDto = new UserPositionBasicDto
                {
                    FullName = x.User.FullName,
                    PositionName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.Position.Name.ToLower()),
                };
                usersDto.Add(userDto);
            });
            

            var task = _context.Tasks.Include(x => x.City).ThenInclude(x => x.Country).
                FirstOrDefault(x => x.Id == taskId);

            var calculatedDays = task.DueDate != null
            ? (DateTime.Now.Date > task.DueDate.Value.Date
                ? $"{(DateTime.Now.Date - task.DueDate.Value.Date).Days} days ago"
                : $"{(task.DueDate.Value.Date - DateTime.Now.Date).Days} days left")
            : "No due date";

            TaskDetailsDto result = new TaskDetailsDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                DueDate = task.DueDate,
                CalculatedDays = calculatedDays,
                Location = $"{task.City.Name}, {task.City.Country.Name}",
                Priority = Enum.GetName(typeof(Enumerations.TaskPriority), task.Priority),
                Status = Enum.GetName(typeof(Enumerations.TaskStatus), task.StatusCode).Replace("_", " "),
                Users = usersDto,
                AllowedReview = allowReview
            };

            return result;

        }


    }
}
