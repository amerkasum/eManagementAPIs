using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class TaskReviewRepository : Repository<TaskReview>, ITaskReviewRepository
    {
        public TaskReviewRepository(ApplicationDbContext context) : base(context) { }

        public List<TaskReviewDto> GetByTaskId(int taskId)
        {

            return _context.TaskReviews.Include(x => x.UserTask).ThenInclude(x => x.User).Where(x => x.UserTask.TaskId == taskId).Select(x => new TaskReviewDto
            {
                TaskId = x.UserTask.TaskId,
                FullName = x.UserTask.User.FullName,
                Review = x.Review,
                Id = x.Id
            }).ToList();
        }

        public TaskReview GetByUserTaskId(int userTaskId)
        {
            return _context.TaskReviews.Include(x => x.UserTask).FirstOrDefault(x => x.UserTask.Id == userTaskId);
        }

        public List<UserTaskReviewData> GetHistoryOfReviews(int userId)
        {
            var tasksOfUser = _context.UserTasks.Where(x => x.UserId == userId).Select(x => x.TaskId).ToList();

            var result = _context.TaskReviews.Include(x => x.UserTask).Where(x => x.UserTask.UserId != userId && tasksOfUser.Contains(x.UserTask.TaskId))
                .Select(x => new UserTaskReviewData
            {
                UserId = (uint)x.UserTask.UserId,
                TaskId = (uint)x.UserTask.TaskId,
                Review = x.Review
            }).ToList();

            return result;
        }
    }
}
