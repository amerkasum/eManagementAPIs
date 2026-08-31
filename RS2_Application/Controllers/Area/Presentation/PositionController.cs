using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Helpers;
using Models.Entities.ViewModels;
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

        [HttpPost(nameof(Add))]
        public IActionResult Add([FromBody] PositionsViewModel model)
        {
            try
            {
                var positions = new Positions
                {
                    Name = model.Name,
                    Code = model.Code
                };

                UnitOfWork.PositionsRepository.Add(positions);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Added, model.Name) });
            }
            catch
            {
                return BadRequest(new { success = false, message = Statics.Notifications.Common.InternalServerError });
            }

        }

        [HttpPut(nameof(Edit))]
        public IActionResult Edit([FromBody] EventStatusViewModel model)
        {
            var positions = UnitOfWork.PositionsRepository.GetById(model.Id);

            if (positions != null)
            {
                positions.Name = model.Name;
                positions.Code = model.Code;
            }

            UnitOfWork.PositionsRepository.Update(positions);
            UnitOfWork.SaveChanges();

            return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Updated, model.Name) });

        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            var positions = UnitOfWork.PositionsRepository.GetById(id);

            if (positions != null)
            {
                UnitOfWork.PositionsRepository.Remove(positions);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Deleted, "Positions") });
            }
            return BadRequest(new { success = false, message = string.Format(Statics.Notifications.Common.NotFound, "Positions") });
        }
    }
}
