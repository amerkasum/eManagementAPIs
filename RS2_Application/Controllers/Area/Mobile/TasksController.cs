using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;
        public TasksController(IUnitOfWork unitOfWork) {
            this.UnitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetAll))]
        public List<TasksDto> GetAll(int? userId)
        {
            return UnitOfWork.TasksRepository.GetTasksByUserId(userId);
        }

        [HttpGet(nameof(GetByStatusCode))]
        public List<TasksDto> GetByStatusCode(int? statusCode)
        {
            return UnitOfWork.TasksRepository.GetTasksByStatusCode(statusCode);
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(TaskViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.BeginTransaction();
                    Tasks task = new Tasks
                    {
                        Name = model.Name,
                        Description = model.Description,
                        DueDate = model.DueDate,
                        Priority = model.Priority,
                        StatusCode = model.Status,
                    };
                    UnitOfWork.TasksRepository.Add(task);
                    UnitOfWork.SaveChanges();

                    if(model.UserIds != null && model.UserIds.Count != 0)
                    {
                        List<UserTasks> userTasks = new List<UserTasks>();
                        model.UserIds.ForEach(userId =>
                        {
                            userTasks.Add(new UserTasks
                            {
                                TaskId = task.Id,
                                UserId = userId
                            });
                        });

                        UnitOfWork.UserTasksRepository.AddRange(userTasks);
                        UnitOfWork.SaveChanges();

                        UnitOfWork.Commit();
                        
                    }

                    return Ok();
                }
                catch
                {
                    UnitOfWork.RollBack();
                    return BadRequest(ModelState);
                }
            }
            return BadRequest();
        }

        public IActionResult ChangeStatus(int taskId, int statusCode)
        {
            try
            {
                var task = UnitOfWork.TasksRepository.GetById(taskId);
                task.StatusCode = statusCode;
                UnitOfWork.TasksRepository.Update(task);
                UnitOfWork.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
            

            return Ok();
        }
    }
}
