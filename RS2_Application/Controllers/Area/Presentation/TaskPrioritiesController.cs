using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Entities.Helpers;
using Models.Entities.ViewModels;
using System.Collections.Generic;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskPrioritiesController : Controller
    {
        private IUnitOfWork UnitOfWork;

        public TaskPrioritiesController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetAll))]
        public List<SelectListHelper> GetAll()
        {
            return UnitOfWork.TaskPrioritiesRepository.GetSelectLists();
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add([FromBody] TaskPrioritiesViewModel model)
        {
            try
            {
                var taskPriorities = new TaskPriorities
                {
                    Name = model.Name,
                    Code = model.Code
                };

                UnitOfWork.TaskPrioritiesRepository.Add(taskPriorities);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Added, model.Name) });
            }
            catch
            {
                return BadRequest(new { success = false, message = Statics.Notifications.Common.InternalServerError });
            }

        }

        [HttpPut(nameof(Edit))]
        public IActionResult Edit([FromBody] TaskPrioritiesViewModel model)
        {
            var taskPriorities = UnitOfWork.TaskPrioritiesRepository.GetById(model.Id);

            if (taskPriorities != null)
            {
                taskPriorities.Name = model.Name;
                taskPriorities.Code = model.Code;
            }

            UnitOfWork.TaskPrioritiesRepository.Update(taskPriorities);
            UnitOfWork.SaveChanges();

            return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Updated, model.Name) });

        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            var taskPriorities = UnitOfWork.TaskPrioritiesRepository.GetById(id);

            if (taskPriorities != null)
            {
                UnitOfWork.TaskPrioritiesRepository.Remove(taskPriorities);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Deleted, "Task priority") });
            }
            return BadRequest(new { success = false, message = string.Format(Statics.Notifications.Common.NotFound, "Task priority") });
        }
    }
}
