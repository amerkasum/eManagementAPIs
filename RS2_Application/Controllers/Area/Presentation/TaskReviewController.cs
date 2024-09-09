using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using System.Collections.Generic;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskReviewController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;
        public TaskReviewController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetByTaskId))]
        public List<TaskReviewDto> GetByTaskId(int taskId)
        {
            return UnitOfWork.TaskReviewRepository.GetByTaskId(taskId);
        }

        [HttpPost(nameof(Review))]
        public IActionResult Review(int userId, int taskId, int review)
        {
            var userTask = UnitOfWork.UserTasksRepository.GetByUserIdAndTaskId(userId, taskId);

            if (userTask == null)
            {
                return BadRequest(new { success = false, message = "Problem with reviewing task. UserTask not found." });
            }

            var existingReview = UnitOfWork.TaskReviewRepository.GetByUserTaskId(userTask.Id);

            if (existingReview != null)
            {
                existingReview.Review = review;
                UnitOfWork.TaskReviewRepository.Update(existingReview);
            }
            else
            {
                var newReview = new TaskReview
                {
                    UserTaskId = userTask.Id,
                    Review = review
                };
                UnitOfWork.TaskReviewRepository.Add(newReview);
            }

            UnitOfWork.SaveChanges();

            return Ok(new { success = true, message = "Review submitted successfully." });
        }


    }
}
