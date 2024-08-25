using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IEventsRepository : IRepository<Events>
    {
        List<EventsDto> GetAllDto();
        EventsDetailsDto GetDetailsById(int id);
    }
}
