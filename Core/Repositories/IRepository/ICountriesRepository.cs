using Models.Entities;
using Models.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface ICountriesRepository : IRepository<Countries>
    {
        CountriesDto GetCountryByName(string name);
        CountriesDto GetCountryByIso(string iso);
    }
}
