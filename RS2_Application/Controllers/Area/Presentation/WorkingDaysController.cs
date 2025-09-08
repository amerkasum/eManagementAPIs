using Core.Repositories.IRepository;
using Core.Services.IServices;
using Core.UnitOfWork;
using Helpers.Constants;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RS2_Application.Controllers.Area.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingDaysController : Controller
    {
        private IUnitOfWork UnitOfWork;
        private IWorkingDaysService WorkingDaysService;
        public WorkingDaysController(IUnitOfWork unitOfWork, IWorkingDaysService workingDaysService) {
            this.UnitOfWork = unitOfWork;
            this.WorkingDaysService = workingDaysService;
        }

        [HttpGet(nameof(GetByUserId))]
        public WorkingDaysDto GetByUserId(int userId)
        {
            return WorkingDaysService.GetWeeklyWorkingDays(userId);
        }

        [HttpPost(nameof(EditWorkingDays))]
        public IActionResult EditWorkingDays([FromBody] List<WorkingDaysBasicDto> models)
        {
            try
            {
                if (models == null || !models.Any())
                    return BadRequest(new { success = false, message = Statics.Notifications.Common.NoDataProvided });

                var workingDaysIds = models.Select(x => x.WorkingDayId).ToList();
                var workingDays = UnitOfWork.WorkingDaysRepository.GetByIds(workingDaysIds);
                var workingDaysToEdit = new List<WorkingDays>();

                foreach (var workingDay in workingDays)
                {
                    var model = models.FirstOrDefault(x => x.WorkingDayId ==  workingDay.Id);

                    if(model != null && (model.IsWorking != workingDay.IsWorking || model.ShiftId != workingDay.ShiftId))
                    {
                        workingDay.IsWorking = model.IsWorking;

                        workingDaysToEdit.Add(workingDay);
                    }
                }
                if(workingDaysToEdit.Any())
                {
                    UnitOfWork.WorkingDaysRepository.UpdateRange(workingDaysToEdit);
                    UnitOfWork.SaveChanges();

                    return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Updated, "Updated") });

                }
                
                return Ok(new { success = true, message = Statics.Notifications.Common.NothindToUpdate });
            }
            catch (Exception ex)
            {
                return StatusCode(500, Statics.Notifications.Common.InternalServerError);
            }
        }




    }
}
