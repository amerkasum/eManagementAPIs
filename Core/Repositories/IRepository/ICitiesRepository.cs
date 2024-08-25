using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.IRepository
{
    public interface ICitiesRepository : IRepository<Cities>
    {
        CitiesDto GetCityByName(string name);
        bool DoesCityAlreadyExist(string cityName, string pttCode);
        List<SelectListHelper> GetSelectLists();
    }
}
