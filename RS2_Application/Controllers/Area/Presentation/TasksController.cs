using Core.Repositories.Repository;
using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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
            return UnitOfWork.TasksRepository.GetAllTasks();
        }

        [HttpGet(nameof(Details))]
        public TaskDetailsDto Details(int taskId, int userId)
        {
            return UnitOfWork.TasksRepository.GetTaskDetails(taskId, userId);
        }

        [HttpPost(nameof(ChangeStatus))]
        public IActionResult ChangeStatus(int taskId, string statusName)
        {
            var task = UnitOfWork.TasksRepository.GetById(taskId);
            if (task != null)
            {
                var taskStatus = UnitOfWork.TaskStatusesRepository.GetByName(statusName);
                task.StatusCode = int.Parse(taskStatus.Code);
                UnitOfWork.TasksRepository.Update(task);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = "Task status updated successfully" });
            }
            else
            {
                return NotFound(new { success = false, message = "Task not found" });
            }
        }



        [HttpPost(nameof(Add))]
        public IActionResult Add([FromBody] TaskViewModel model)
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
                        Priority = model.TaskPriorityId,
                        StatusCode = (int)Enumerations.TaskStatus.PENDING,
                        CityId = model.CityId
                    };
                    UnitOfWork.TasksRepository.Add(task);
                    UnitOfWork.SaveChanges();

                    if(model.UserIds != null)
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
    }
}
