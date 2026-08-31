using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Helpers;
using Models.Entities.ViewModels;
using System.Collections.Generic;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventStatusesController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;
        public EventStatusesController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetAll))]
        public List<SelectListHelper> GetAll()
        {
            return UnitOfWork.EventStatusesRepository.GetSelectLists();
        }

        [HttpPost(nameof(Add))]

        public IActionResult Add([FromBody] EventStatusViewModel model)
        {
            try
            {
                var eventStatus = new EventStatuses
                {
                    Name = model.Name,
                    Code = model.Code
                };

                UnitOfWork.EventStatusesRepository.Add(eventStatus);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Added, model.Name) });
            }
            catch
            {
                return BadRequest(new { success = false, message = Statics.Notifications.Common.InternalServerError });
            }

        }

        [HttpPut(nameof(Edit))]
        public IActionResult Edit([FromBody] EventStatusViewModel model)
        {
            var eventStatus = UnitOfWork.EventStatusesRepository.GetById(model.Id);

            if (eventStatus != null)
            {
                eventStatus.Name = model.Name;
                eventStatus.Code = model.Code;
            }

            UnitOfWork.EventStatusesRepository.Update(eventStatus);
            UnitOfWork.SaveChanges();

            return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Updated, model.Name) });

        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            var eventStatus = UnitOfWork.EventStatusesRepository.GetById(id);

            if (eventStatus != null)
            {
                UnitOfWork.EventStatusesRepository.Remove(eventStatus);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Deleted, "Contract type") });
            }
            return BadRequest(new { success = false, message = string.Format(Statics.Notifications.Common.NotFound, "Contract type") });
        }
    }
}
