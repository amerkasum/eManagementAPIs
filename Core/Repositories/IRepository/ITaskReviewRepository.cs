using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.ML;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface ITaskReviewRepository : IRepository<TaskReview>
    {
        List<TaskReviewDto> GetByTaskId(int taskId);
        List<UserTaskReviewData> GetHistoryOfReviews(int userId);
    }
}
