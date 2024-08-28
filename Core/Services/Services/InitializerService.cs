using Core.Services.IServices;
using Core.UnitOfWork;
using Helpers.Constants;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static Helpers.Constants.Enumerations;

namespace Core.Services.Services
{
    public  class InitializerService : IInitializerService
    {
        private readonly IUnitOfWork UnitOfWork;

        public InitializerService(IUnitOfWork unitOfWork) {
            this.UnitOfWork = unitOfWork;
        }

        public void Initialize()   
        {

            var hasCities = UnitOfWork.CitiesRepository.Any();

            if (!hasCities)
            {
                var country = UnitOfWork.CountriesRepository.GetCountryByIso("BA");

                List<Cities> cities = new List<Cities>
                {
                    new Cities { Name = "Sarajevo", PttCode = "71000", CountryId = country.Id },
                    new Cities { Name = "Banja Luka", PttCode = "78000", CountryId = country.Id },
                    new Cities { Name = "Mostar", PttCode = "88000", CountryId = country.Id },
                    new Cities { Name = "Tuzla", PttCode = "75000", CountryId = country.Id },
                    new Cities { Name = "Zenica", PttCode = "72000", CountryId = country.Id },
                    new Cities { Name = "Bijeljina", PttCode = "76300", CountryId = country.Id },
                    new Cities { Name = "Prijedor", PttCode = "79101", CountryId = country.Id },
                    new Cities { Name = "Brčko", PttCode = "76100", CountryId = country.Id },
                    new Cities { Name = "Cazin", PttCode = "77220", CountryId = country.Id },
                    new Cities { Name = "Doboj", PttCode = "74000", CountryId = country.Id },
                    new Cities { Name = "Bihać", PttCode = "77000", CountryId = country.Id },
                    new Cities { Name = "Gradiška", PttCode = "78400", CountryId = country.Id },
                    new Cities { Name = "Trebinje", PttCode = "89101", CountryId = country.Id },
                    new Cities { Name = "Travnik", PttCode = "72270", CountryId = country.Id },
                    new Cities { Name = "Tešanj", PttCode = "74260", CountryId = country.Id },
                    new Cities { Name = "Visoko", PttCode = "71300", CountryId = country.Id },
                    new Cities { Name = "Sanski Most", PttCode = "79260", CountryId = country.Id },
                    new Cities { Name = "Bugojno", PttCode = "70230", CountryId = country.Id },
                    new Cities { Name = "Živinice", PttCode = "75270", CountryId = country.Id },
                    new Cities { Name = "Lukavac", PttCode = "75300", CountryId = country.Id },
                    new Cities { Name = "Foča", PttCode = "73300", CountryId = country.Id },
                    new Cities { Name = "Goražde", PttCode = "73000", CountryId = country.Id },
                    new Cities { Name = "Konjic", PttCode = "88400", CountryId = country.Id },
                    new Cities { Name = "Livno", PttCode = "80101", CountryId = country.Id },
                    new Cities { Name = "Neum", PttCode = "88390", CountryId = country.Id },
                    new Cities { Name = "Posušje", PttCode = "88240", CountryId = country.Id },
                    new Cities { Name = "Široki Brijeg", PttCode = "88220", CountryId = country.Id },
                    new Cities { Name = "Srebrenica", PttCode = "75430", CountryId = country.Id },
                    new Cities { Name = "Tomislavgrad", PttCode = "80240", CountryId = country.Id },
                    new Cities { Name = "Vitez", PttCode = "72250", CountryId = country.Id }
                };


                UnitOfWork.CitiesRepository.AddRange(cities);
                UnitOfWork.SaveChanges();
            }
        }
    }
}
