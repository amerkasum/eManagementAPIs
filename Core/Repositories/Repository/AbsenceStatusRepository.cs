using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class AbsenceStatusRepository : Repository<AbsenceStatuses>, IAbsenceStatusRepository
    {
        public AbsenceStatusRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public AbsenceStatuses GetByName(string absenceName)
        {
            return _context.AbsenceStatuses.FirstOrDefault(x => x.Name.ToLower().Equals(absenceName.ToLower()));
        }
    }
}
