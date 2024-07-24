using Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.Dtos;
using RS2_Application.ViewModels;
using System.Collections.Generic;

namespace RS2_Application.Controllers.Area.Regions
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly IUnitOfWork DataUnitOfWork;
        public CountriesController(IUnitOfWork unitOfWork)
        {
            this.DataUnitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetAll))]
        public IEnumerable<Countries> GetAll()
        {
            //TODO
            return DataUnitOfWork.CountriesRepository.GetAll();
        }

        [HttpGet(nameof(GetByName))]
        public CountriesDto GetByName(string name)
        {
            return DataUnitOfWork.CountriesRepository.GetCountryByName(name);
        }

    }
}
