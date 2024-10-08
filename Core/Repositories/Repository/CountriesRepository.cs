﻿using Core.DatabaseContext;
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
        public CountriesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public CountriesDto GetCountryByIso(string iso)
        {
            var country = _context.Countries.FirstOrDefault(x => x.Iso.ToLower().Equals(iso.ToLower()));
            return new CountriesDto { Name = country.Name, Iso = country.Iso, Id = country.Id };
        }

        public CountriesDto GetCountryByName(string name)
        {
            var country = _context.Countries.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
            return new CountriesDto { Name = country.Name, Iso = country.Iso, Id = country.Id };
        }


    }
}
