using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class CitiesRepository : Repository<Cities>, ICitiesRepository
    {
        public CitiesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public CitiesDto GetCityByName(string name)
        {
            var result = _context.Cities.Include(x => x.Country).FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            return new CitiesDto
            {
                Id = result.Id,
                Name = result.Name,
                PttCode = result.PttCode,
                CountryName = result.Country.Name,
                CountryId = result.CountryId
            };
        }

        public bool DoesCityAlreadyExist(string cityName, string pttCode)
        {
            return _context.Cities.Any(x => x.Name.ToLower().Equals(cityName.ToLower()) && x.PttCode.ToLower().Equals(pttCode.ToLower()));
        }

        public List<SelectListHelper> GetSelectLists()
        {
            var result = _context.Cities.Select(x => new SelectListHelper
            {
                Id = x.Id,
                Name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.Name.ToLower()),
                Code = "none"
            }).ToList();

            return result;
        }
    }
}
