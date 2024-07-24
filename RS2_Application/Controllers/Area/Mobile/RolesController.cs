using Core.Services.IServices;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

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


        #region Add

        #endregion

        #region Edit

        #endregion

        #region Delete

        #endregion
    }
}
