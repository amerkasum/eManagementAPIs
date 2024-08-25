using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Helpers;
using System.Collections.Generic;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;

        public PositionController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }


        [HttpGet(nameof(GetAll))]
        public List<SelectListHelper> GetAll()
        {
            return UnitOfWork.PositionsRepository.GetSelectLists();
        }
    }
}
