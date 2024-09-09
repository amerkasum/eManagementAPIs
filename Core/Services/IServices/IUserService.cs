using Models.Entities.Dtos;
using Models.Entities.ML;
using RS2_Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.IServices
{
    public interface IUserService
    {
        void HandleUserData(int userId, UsersViewModel model);
        List<int> RecommendUsersForTask(int userId, List<UserTaskReviewData> potentialUsers);
        void TrainModel(List<UserTaskReviewData> userTaskReviews);
    }
}
