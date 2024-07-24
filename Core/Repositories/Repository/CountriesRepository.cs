using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class CountriesRepository : Repository<Countries>, ICountriesRepository
    {
        public CountriesRepository(MyContext context) : base(context)
        {
        }

        public CountriesDto GetCountryByName(string name)
        {
            var country = _context.Countries.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
            return new CountriesDto { Name = country.Name, Iso = country.Iso, Id = country.Id };
        }


    }
}
