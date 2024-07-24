using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using RS2_Application.ViewModels;
using System.Collections;
using System.Data.Odbc;

namespace RS2_Application.Controllers.Area.Regions
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly IUnitOfWork DataUnitOfWork;
        public CitiesController(IUnitOfWork unitOfWork)
        {
            this.DataUnitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetCityByName))]
        public CitiesDto GetCityByName(string name)
        {
            return DataUnitOfWork.CitiesRepository.GetCityByName(name);
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(CitiesViewModel model)
        {
            if (DataUnitOfWork.CitiesRepository.DoesCityAlreadyExist(model.Name, model.PttCode))
                ModelState.AddModelError("Cities", "This city already exist in our database!");

            if(ModelState.IsValid)
            {
                var countryResult = DataUnitOfWork.CountriesRepository.GetCountryByName(model.CountryName);
                try
                {
                    DataUnitOfWork.BeginTransaction();
                    if (countryResult == null)
                    {
                        Countries country = new Countries
                        {
                            Name = model.CountryName
                        };
                        DataUnitOfWork.CountriesRepository.Add(country);
                        DataUnitOfWork.Complete();
                    }
                    else
                    {
                        Cities city = new Cities
                        {
                            Name = model.Name,
                            PttCode = model.PttCode,
                            CountryId = countryResult.Id
                        };
                        DataUnitOfWork.CitiesRepository.Add(city);
                        DataUnitOfWork.Complete();
                    }
                    DataUnitOfWork.Commit();

                    return Ok();
                }
                catch
                {
                    DataUnitOfWork.RollBack();
                    return BadRequest();
                }
            }
            return BadRequest(ModelState);
            
        }

    }
}
