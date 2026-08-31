using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.ViewModels;
using System.Collections.Generic;

namespace RS2_Application.Controllers.Area.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusesController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        public TaskStatusesController(IUnitOfWork unitOfwork)
        {
            this.UnitOfWork = unitOfwork;
        }

        [HttpGet]
        public IEnumerable<TaskStatuses> GetAll()
        {
            return UnitOfWork.TaskStatusesRepository.GetAll();
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add([FromBody] TaskStatusesViewModel model)
        {
            try
            {
                var taskStatuses = new TaskStatuses
                {
                    Name = model.Name,
                    Code = model.Code
                };

                UnitOfWork.TaskStatusesRepository.Add(taskStatuses);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Added, model.Name) });
            }
            catch
            {
                return BadRequest(new { success = false, message = Statics.Notifications.Common.InternalServerError });
            }

        }

        [HttpPut(nameof(Edit))]
        public IActionResult Edit([FromBody] TaskStatusesViewModel model)
        {
            var taskStatuses = UnitOfWork.TaskStatusesRepository.GetById(model.Id);

            if (taskStatuses != null)
            {
                taskStatuses.Name = model.Name;
                taskStatuses.Code = model.Code;
            }

            UnitOfWork.TaskStatusesRepository.Update(taskStatuses);
            UnitOfWork.SaveChanges();

            return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Updated, model.Name) });

        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            var taskStatuses = UnitOfWork.TaskStatusesRepository.GetById(id);

            if (taskStatuses != null)
            {
                UnitOfWork.TaskStatusesRepository.Remove(taskStatuses);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Deleted, "Task status") });
            }
            return BadRequest(new { success = false, message = string.Format(Statics.Notifications.Common.NotFound, "Task status") });
        }
    }
}
