using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.Repository
{
    public class AbsenceTypesRepository : Repository<AbsenceTypes>, IAbsenceTypesRepository
    {
        public AbsenceTypesRepository(ApplicationDbContext context) : base(context) { }
    }
}
