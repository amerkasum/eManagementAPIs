using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.Repository
{
    public class EventStatusesRepository : Repository<EventStatuses>, IEventStatusesRepository
    {
        public EventStatusesRepository(MyContext context) : base(context) { }
    }
}
