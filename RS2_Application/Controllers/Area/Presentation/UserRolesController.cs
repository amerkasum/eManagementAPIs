using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace RS2_Application.Controllers.Area.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : Controller
    {
        private readonly IUnitOfWork DataUnitOfWork;
        public UserRolesController(IUnitOfWork unitOfWork)
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
