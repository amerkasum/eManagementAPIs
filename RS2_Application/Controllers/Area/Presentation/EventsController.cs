using Core.Services.HelperServices.IHelperService;
using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IHelperService HelperService;
        public EventsController(IUnitOfWork unitOfWork, IHelperService helperService)
        {
            this.UnitOfWork = unitOfWork;
            this.HelperService = helperService;
        }


        [HttpGet(nameof(GetAll))]
        public List<EventsDto> GetAll()
        {
            return UnitOfWork.EventsRepository.GetAllDto();
        }

        [HttpGet(nameof(Details))]
        public EventsDetailsDto Details(int eventId)
        {
            return UnitOfWork.EventsRepository.GetDetailsById(eventId);
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(EventViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Events e = new Events
                    {
                        Title = model.Title,
                        Subtitle = model.Subtitle,
                        Description = model.Description,
                        CreatedById = model.CreatedById,
                        Date = model.Date,
                        EventStatusId = model.EventStatusId,
                        ImageUrl = model.ImageUrl
                    };

                    UnitOfWork.EventsRepository.Add(e);
                    UnitOfWork.SaveChanges();

                    return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Added, e.Title) });
                }
                var errorMessage = HelperService.ModelStateErrorMessageGenerator(ModelState);
                return BadRequest(new { success = false, message = errorMessage });
                
            }
            catch
            {
                return BadRequest(new { success = false, message = Statics.Notifications.Common.InternalServerError });
            }

        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id) {
            var e = UnitOfWork.EventsRepository.GetById(id);

            if (e != null)
            {
                UnitOfWork.EventsRepository.Remove(e);
                UnitOfWork.SaveChanges();
                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Deleted, e.Title) });
            }
            return BadRequest(new { success = false, message = string.Format(Statics.Notifications.Common.NotFound, "Event") });

        }
    }
}
