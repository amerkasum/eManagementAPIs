using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.Repository
{
    public class EventsRepository : Repository<Events>, IEventsRepository
    {
        public EventsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
