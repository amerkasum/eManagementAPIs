using Core.Services.IServices;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Models.Entities.Helpers;
using System.Collections.Generic;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IUnitOfWork DataUnitOfWork;
        public RolesController(IUnitOfWork unitOfWork)
        {
            this.DataUnitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetAll))]
        public List<SelectListHelper> GetAll()
        {
            return DataUnitOfWork.RolesRepository.GetSelectLists();
        }
    }
}
