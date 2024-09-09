using Core.Services.IServices;
using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using static Helpers.Constants.Enumerations;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingAbsenceController : Controller
    {
        private IUnitOfWork UnitOfWork;
        private IWorkingAbsenceService WorkingAbsenceService;
        public WorkingAbsenceController(IUnitOfWork unitOfWork, IWorkingAbsenceService workingAbsenceService)
        {
            this.UnitOfWork = unitOfWork;
            this.WorkingAbsenceService = workingAbsenceService;
        }


        [HttpGet(nameof(GetWorkingAbsences))]
        public List<WorkingAbsenceBasicDto> GetWorkingAbsences(int userId) {
            return UnitOfWork.WorkingAbsencesRepository.GetWorkingAbsences(userId);
        }

        [HttpPost(nameof(ChangeStatus))]
        public IActionResult ChangeStatus(int workingAbsenceId, string statusName)
        {
            var workingAbsence = UnitOfWork.WorkingAbsencesRepository.GetById(workingAbsenceId);
            if (workingAbsence != null)
            {
                var absenceStatus = UnitOfWork.AbsenceStatusRepository.GetByName(statusName);
                workingAbsence.AbsenceStatusId = absenceStatus.Id;
                UnitOfWork.WorkingAbsencesRepository.Update(workingAbsence);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = "Working absence status updated successfully" });
            }
            else
            {
                return NotFound(new { success = false, message = "Working absence not found" });
            }
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add([FromBody] WorkingAbsenceViewModel model)
        {            
            try
            {
                var absenceStatus = UnitOfWork.AbsenceStatusRepository.GetByName(nameof(Enumerations.AbsenceStatus.REQUEST));
                WorkingAbsences workingAbsence = new WorkingAbsences
                {
                    AbsenceTypeId = model.AbsenceTypeId,
                    AbsenceStatusId = absenceStatus.Id,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    UserId = model.UserId,
                    Note = model.Note
                };

                UnitOfWork.WorkingAbsencesRepository.Add(workingAbsence);
                UnitOfWork.SaveChanges();

                return Ok(new { message = "Working Absence added successfuly." });
            }
            catch
            {
                return BadRequest(new { Message = "Working Absence add failed." });
            }
        }
    }
}
