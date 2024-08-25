using Models.Entities;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IPositionsRepository : IRepository<Positions>
    {
        List<SelectListHelper> GetSelectLists();
    }
}
