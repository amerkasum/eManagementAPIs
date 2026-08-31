using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Models.Entities;
using Models.Entities.Helpers;
using Models.Entities.ViewModels;
using System.Collections.Generic;
using static Helpers.Constants.Enumerations;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceTypeController : Controller
    {
        private IUnitOfWork UnitOfWork;
        public AbsenceTypeController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetAll))]
        public List<SelectListHelper> GetAll()
        {
            return UnitOfWork.AbsenceTypesRepository.GetSelectLists();
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add([FromBody] AbsenceTypeViewModel model)
        {
            try
            {
                var absenceType = new AbsenceTypes
                {
                    Name = model.Name,
                    Code = model.Code
                };

                UnitOfWork.AbsenceTypesRepository.Add(absenceType);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Added, model.Name) });
            }
            catch
            {
                return BadRequest(new { success = false, message = Statics.Notifications.Common.InternalServerError });
            }

        }

        [HttpPut(nameof(Edit))]
        public IActionResult Edit([FromBody] AbsenceTypeViewModel model)
        {
            var absenceType = UnitOfWork.AbsenceTypesRepository.GetById(model.Id);

            if(absenceType != null )
            {
                absenceType.Name = model.Name;
                absenceType.Code = model.Code;
            }

            UnitOfWork.AbsenceTypesRepository.Update(absenceType);
            UnitOfWork.SaveChanges();

            return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Updated, model.Name) });

        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            var absenceType = UnitOfWork.AbsenceTypesRepository.GetById(id);

            if(absenceType != null )
            {
                UnitOfWork.AbsenceTypesRepository.Remove(absenceType);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Deleted, "Absence type") });
            }
            return BadRequest(new { success = false, message = string.Format(Statics.Notifications.Common.NotFound, "Absence type") });
        }
    }
}
