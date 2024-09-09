using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IAbsenceStatusRepository : IRepository<AbsenceStatuses>
    {
        AbsenceStatuses GetByName(string absenceName);
    }
}
