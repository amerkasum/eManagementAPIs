using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Helpers;
using System.Collections.Generic;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;

        public ShiftController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }


        [HttpGet(nameof(GetAll))]
        public IEnumerable<SelectListHelper> GetAll()
        {
            return UnitOfWork.ShiftsRepository.GetSelectLists();
        }
    }
}
