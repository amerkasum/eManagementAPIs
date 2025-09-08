using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;
        public EventsController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
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

                return Ok( new { success = true, message = string.Format(Statics.Notifications.Common.Added, e.Title) });
            }
            catch
            {
                return BadRequest(new { success = false, message = Statics.Notifications.Common.InternalServerError });
            }

        }
    }
}
