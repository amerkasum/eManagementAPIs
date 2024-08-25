using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class EventsRepository : Repository<Events>, IEventsRepository
    {
        public EventsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<EventsDto> GetAllDto()
        {
            List<EventsDto> rerponse = _context.Events.Select(x => new EventsDto
            {
                Id = x.Id,
                Subtitle = x.Subtitle,
                Title = x.Title,
                Date = x.Date,
                EventStatusCode = x.EventStatusId,
                ImageUrl = x.ImageUrl ?? "assets/default.jpg"
            }).ToList();

            return rerponse;
        }

        public EventsDetailsDto GetDetailsById(int id)
        {
            var result = _context.Events.Where(x => x.Id == id).Select(x => new EventsDetailsDto
            {
                Id = x.Id,
                Title = x.Title,
                Subtitle = x.Subtitle,
                Date = x.Date,
                EventStatusCode = x.EventStatusId,
                Description = x.Description,
                CreatedById = x.CreatedById,
                CreatedByFullName = _context.Users.FirstOrDefault(y => y.Id == x.CreatedById).FullName,
                ImageUrl = x.ImageUrl ?? "assets/default.jpg"
            }).FirstOrDefault();

            return result;

        }


    }
}
