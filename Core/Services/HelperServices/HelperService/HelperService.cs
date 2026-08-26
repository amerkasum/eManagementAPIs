using Helpers.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.HelperServices.HelperService
{
    public class HelperService : IHelperService.IHelperService
    {

        private readonly IRazorViewEngine RazorViewEngine;
        private readonly ITempDataProvider TempDataProvider;
        private readonly IServiceProvider ServiceProvider;
        public HelperService(IRazorViewEngine razorViewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider) {
            this.RazorViewEngine = razorViewEngine;
            this.TempDataProvider = tempDataProvider;
            this.ServiceProvider = serviceProvider;
        }

        public List<DateTime> GetCurrentWeek()
        {
            List<DateTime> week = new List<DateTime>();

            DateTime today = DateTime.Today;
            int delta = DayOfWeek.Monday - today.DayOfWeek;
            DateTime startOfWeek = today.AddDays(delta);

            for (int i = 0; i < 7; i++)
            {
                week.Add(startOfWeek.AddDays(i));
            }

            return week;
        }

        public async Task<string> RenderRazorViewToString(string viewName, CreatedAccountTemplateModel model)
        {
            var httpContext = new DefaultHttpContext { RequestServices = ServiceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using (var sw = new StringWriter())
            {
                var viewResult = RazorViewEngine.FindView(actionContext, viewName, false);

                if (viewResult.View == null)
                {
                    var searchedLocations = string.Join(Environment.NewLine, viewResult.SearchedLocations);
                    throw new ArgumentNullException($"{viewName} does not match any available view. Searched locations: {searchedLocations}");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, TempDataProvider),
                    sw,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);
                return sw.ToString();
            }
        }

        public string ModelStateErrorMessageGenerator(ModelStateDictionary modelState)
        {
            var errorMessages =  modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToString();
            return errorMessages;
        } 


    }    
}
