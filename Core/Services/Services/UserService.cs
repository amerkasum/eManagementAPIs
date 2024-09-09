using Core.Services.IServices;
using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.ML;
using RS2_Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services.Services
{
    public class UserService : IUserService
    {
        private MLContext MlContext;
        private ITransformer Model;
        private readonly IUnitOfWork UnitOfWork;
        private readonly IUserLoggerService UserLoggerService;
        public UserService(IUnitOfWork unitOfWork, IUserLoggerService userLoggerService)
        {
            this.UnitOfWork = unitOfWork;
            this.UserLoggerService = userLoggerService;
            this.MlContext = new MLContext();
        }

        #region Recommender Engine
        public void TrainModel(List<UserTaskReviewData> userTaskReviews)
        {
            if(userTaskReviews.Count() != 0)
            {
                var dataView = MlContext.Data.LoadFromEnumerable(userTaskReviews);

                var options = new MatrixFactorizationTrainer.Options
                {
                    MatrixColumnIndexColumnName = nameof(UserTaskReviewData.UserId),
                    MatrixRowIndexColumnName = nameof(UserTaskReviewData.TaskId),
                    LabelColumnName = nameof(UserTaskReviewData.Review),
                    LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                    NumberOfIterations = 10,
                    ApproximationRank = 10,
                    Alpha = 0.1,
                    Lambda = 0.1

                };

                var trainingPipeline = MlContext.Recommendation().Trainers.MatrixFactorization(options);

                Model = trainingPipeline.Fit(dataView);
            }           
        }

        public List<int> RecommendUsersForTask(int userId, List<UserTaskReviewData> potentialUsers)
        {
            if (potentialUsers.Count() == 0)
            {
                return new List<int>();
            }
            var predictionEngine = MlContext.Model.CreatePredictionEngine<UserTaskReviewData, TaskReviewPrediction>(Model);

            var recommendations = new List<(int userId, float score)>();

            foreach (var potentialUser in potentialUsers)
            {
                var input = new UserTaskReviewData { UserId = (uint)potentialUser.UserId, Review = potentialUser.Review };
                var prediction = predictionEngine.Predict(input);
                recommendations.Add(((int)potentialUser.UserId, prediction.Score));
            }

            return recommendations.OrderByDescending(r => r.score).Take(1).Select(r => r.userId).ToList();
        }
        #endregion

        public void HandleUserData(int userId, UsersViewModel model)
        {
            UserRoles userRoles = new UserRoles
            {
                UserId = userId,
                RoleId = model.RoleId
            };

            UnitOfWork.UserRolesRepository.Add(userRoles);
            UnitOfWork.SaveChanges();

            List<WorkingDays> workingDays = new List<WorkingDays>
            {
                new WorkingDays
                {
                    Description = null,
                    Day = 1,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 2,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 3,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 4,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 5,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = true
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 6,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = false
                },
                new WorkingDays
                {
                    Description = null,
                    Day = 7,
                    Date = null,
                    UserId = userId,
                    ShiftId = model.ShiftId,
                    RepeatState = (int)Enumerations.RepeatState.ALWAYS,
                    IsWorking = false
                }
            };

            UnitOfWork.WorkingDaysRepository.AddRange(workingDays);
            UnitOfWork.SaveChanges();

            UserResidence userResidence = new UserResidence
            {
                UserId = userId,
                CityId = model.CityId
            };

            UnitOfWork.UserResidenceRepository.Add(userResidence);
            UnitOfWork.SaveChanges();


            UserPositions userPosition = new UserPositions
            {
                UserId = userId,
                PositionId = model.PositionId,
                ContractTypeCode = UnitOfWork.ContractTypeRepository.GetById(model.ContractTypeId).Code,
                ContractExpireDate = model.ContractExpireDate,
            };

            UnitOfWork.UserPositionsRepository.Add(userPosition);
            UnitOfWork.SaveChanges();
        }
    }
}
