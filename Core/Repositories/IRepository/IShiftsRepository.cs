using Models.Entities;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IShiftsRepository : IRepository<Shifts>
    {
        List<SelectListHelper> GetSelectLists();
    }
}
