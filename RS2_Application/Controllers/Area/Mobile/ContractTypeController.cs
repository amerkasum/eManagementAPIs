using Core.Migrations;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Helpers;
using System.Collections.Generic;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractTypeController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;

        public ContractTypeController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }


        [HttpGet(nameof(GetAll))]
        public List<SelectListHelper> GetAll()
        {
            return UnitOfWork.ContractTypeRepository.GetSelectLists();
        }
    }
}
