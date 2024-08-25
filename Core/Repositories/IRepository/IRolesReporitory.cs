using Models.Entities;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IRolesReporitory : IRepository<Roles>
    {
        List<SelectListHelper> GetSelectLists();
    }
}
