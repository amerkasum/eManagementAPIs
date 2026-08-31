using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Helpers;
using Models.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RS2_Application.Controllers.Area.Presentation
{
    public class AbsenceStatusController : Controller
    {
        private IUnitOfWork UnitOfWork;
        public AbsenceStatusController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetAll))]
        public List<AbsenceStatuses> GetAll()
        {
            return UnitOfWork.AbsenceStatusRepository.GetAll().ToList();
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add([FromBody] AbsenceStatusViewModel model)
        {
            try
            {
                var absenceStatus = new AbsenceStatuses
                {
                    Name = model.Name,
                    Code = model.Code
                };

                UnitOfWork.AbsenceStatusRepository.Add(absenceStatus);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Added, model.Name) });
            }
            catch
            {
                return BadRequest(new { success = false, message = Statics.Notifications.Common.InternalServerError });
            }

        }

        [HttpPatch(nameof(Edit))]
        public IActionResult Edit([FromBody] AbsenceStatusViewModel model)
        {
            var absenceStatus = UnitOfWork.AbsenceStatusRepository.GetById(model.Id);

            if (absenceStatus != null)
            {
                absenceStatus.Name = model.Name;
                absenceStatus.Code = model.Code;
            }

            UnitOfWork.AbsenceStatusRepository.Update(absenceStatus);
            UnitOfWork.SaveChanges();

            return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Updated, model.Name) });

        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            var absenceStatus = UnitOfWork.AbsenceStatusRepository.GetById(id);

            if (absenceStatus != null)
            {
                UnitOfWork.AbsenceStatusRepository.Remove(absenceStatus);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Deleted, "Absence status") });
            }
            return BadRequest(new { success = false, message = string.Format(Statics.Notifications.Common.NotFound, "Absence status") });
        }
    }
}
