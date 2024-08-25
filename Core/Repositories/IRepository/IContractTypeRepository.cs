using Models.Entities;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface IContractTypeRepository : IRepository<ContractTypes>
    {
        List<SelectListHelper> GetSelectLists();
    }
}
