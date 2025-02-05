using Models.Entities.Templates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.HelperServices.IHelperService
{
    public interface IHelperService
    {
        List<DateTime> GetCurrentWeek();
        Task<string> RenderRazorViewToString(string viewName, CreatedAccountTemplateModel model);
    }
}
