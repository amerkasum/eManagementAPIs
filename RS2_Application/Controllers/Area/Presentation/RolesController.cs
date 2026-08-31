using Core.Services.IServices;
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
    public class RolesController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;
        public RolesController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetAll))]
        public List<SelectListHelper> GetAll()
        {
            return UnitOfWork.RolesRepository.GetSelectLists();
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add([FromBody] RolesViewModel model)
        {
            try
            {
                var roles = new Roles
                {
                    Name = model.Name,
                    Code = model.Code,
                    Description = model.Description
                };

                UnitOfWork.RolesRepository.Add(roles);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Added, model.Name) });
            }
            catch
            {
                return BadRequest(new { success = false, message = Statics.Notifications.Common.InternalServerError });
            }

        }

        [HttpPut(nameof(Edit))]
        public IActionResult Edit([FromBody] RolesViewModel model)
        {
            var roles = UnitOfWork.RolesRepository.GetById(model.Id);

            if (roles != null)
            {
                roles.Name = model.Name;
                roles.Code = model.Code;
                roles.Description = model.Description;
            }

            UnitOfWork.RolesRepository.Update(roles);
            UnitOfWork.SaveChanges();

            return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Updated, model.Name) });

        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            var roles = UnitOfWork.RolesRepository.GetById(id);

            if (roles != null)
            {
                UnitOfWork.RolesRepository.Remove(roles);
                UnitOfWork.SaveChanges();

                return Ok(new { success = true, message = string.Format(Statics.Notifications.Common.Deleted, "Roles") });
            }
            return BadRequest(new { success = false, message = string.Format(Statics.Notifications.Common.NotFound, "Roles") });
        }
    }
}
