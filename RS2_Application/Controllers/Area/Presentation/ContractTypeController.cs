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


        [HttpPost(nameof(Add))]
        public IActionResult Add([FromBody] ContractTypeViewModel model)
        {
            try
            {
                var contractType = new ContractTypes
                {
                    Name = model.Name,
                    Code = model.Code
                };

                UnitOfWork.ContractTypeRepository.Add(contractType);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Added, model.Name) });
            }
            catch
            {
                return BadRequest(new { success = false, message = Statics.Notifications.Common.InternalServerError });
            }

        }

        [HttpPut(nameof(Edit))]
        public IActionResult Edit([FromBody] ContractTypeViewModel model)
        {
            var contractType = UnitOfWork.ContractTypeRepository.GetById(model.Id);

            if (contractType != null)
            {
                contractType.Name = model.Name;
                contractType.Code = model.Code;
            }

            UnitOfWork.ContractTypeRepository.Update(contractType);
            UnitOfWork.SaveChanges();

            return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Updated, model.Name) });

        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            var contractType = UnitOfWork.ContractTypeRepository.GetById(id);

            if (contractType != null)
            {
                UnitOfWork.ContractTypeRepository.Remove(contractType);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Deleted, "Contract type") });
            }
            return BadRequest(new { success = false, message = string.Format(Statics.Notifications.Common.NotFound, "Contract type") });
        }

    }
}
