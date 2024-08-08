using Core.Services.IServices;
using Core.UnitOfWork;
using Helpers.Constants;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var hasShifts = UnitOfWork.ShiftsRepository.Any();
            var hasRoles = UnitOfWork.RolesRepository.Any();
            var hasEventStatuses = UnitOfWork.EventStatusesRepository.Any();
            var hasTaskStatuses = UnitOfWork.TaskStatusesRepository.Any();
            var hasCities = UnitOfWork.CitiesRepository.Any();
            var hasCountries = UnitOfWork.CountriesRepository.Any();
            var hasAbsenceTypes = UnitOfWork.AbsenceTypesRepository.Any();


            if (!hasShifts)
            {
                List<Shifts> shifts = new List<Shifts>
                {
                    new Shifts { Name = nameof(Enumerations.ShiftType.FIRST), TimeFrom = new DateTime(2000, 1,1, 8,0,0), TimeTo = new DateTime(2000,1,1,16,0,0), Code = ((int) Enumerations.ShiftType.FIRST).ToString()  },
                    new Shifts { Name = nameof(Enumerations.ShiftType.SECOND), TimeFrom = new DateTime(2000,1,1,16,0,0), TimeTo = new DateTime(2000,1,1,0,0,0), Code = ((int) Enumerations.ShiftType.SECOND).ToString() },
                    new Shifts { Name = nameof(Enumerations.ShiftType.THIRD), TimeFrom = new DateTime(2000,1,1, 0,0,0), TimeTo = new DateTime(2000, 1,1,8,0,0), Code = ((int) Enumerations.ShiftType.THIRD).ToString() }
                };
                UnitOfWork.ShiftsRepository.AddRange(shifts);
                UnitOfWork.SaveChanges();
            }


            if (!hasRoles)
            {
                List<Roles> roles = new List<Roles>
                {
                    new Roles { Name = nameof(Enumerations.Role.ADMINISTRATOR), Code = ((int)Enumerations.Role.ADMINISTRATOR).ToString() },
                    new Roles { Name = nameof(Enumerations.Role.EMPLOYEE), Code = ((int)Enumerations.Role.EMPLOYEE).ToString() },
                };
                UnitOfWork.RolesRepository.AddRange(roles);
                UnitOfWork.SaveChanges();
            }

            if (!hasEventStatuses)
            {
                List<EventStatuses> eventStatuses = new List<EventStatuses>
                {
                    new EventStatuses { Name = nameof(Enumerations.EventStatus.UPCOMING), Code = ((int)Enumerations.EventStatus.UPCOMING).ToString() },
                    new EventStatuses { Name = nameof(Enumerations.EventStatus.ONGOING), Code = ((int)Enumerations.EventStatus.ONGOING).ToString() },
                    new EventStatuses { Name = nameof(Enumerations.EventStatus.FINISHED), Code = ((int)Enumerations.EventStatus.FINISHED).ToString() },
                    new EventStatuses { Name = nameof(Enumerations.EventStatus.CANCELLED), Code = ((int)Enumerations.EventStatus.CANCELLED).ToString() },
                    new EventStatuses { Name = nameof(Enumerations.EventStatus.CANCELLED), Code = ((int)Enumerations.EventStatus.CANCELLED).ToString() },
                };
                UnitOfWork.EventStatusesRepository.AddRange(eventStatuses);
                UnitOfWork.SaveChanges();
            }

            if (!hasTaskStatuses)
            {
                List<TaskStatuses> taskStatuses = new List<TaskStatuses>
                {
                    new TaskStatuses { Name = nameof(Enumerations.TaskStatus.PENDING), Code = ((int)Enumerations.TaskStatus.PENDING).ToString() },
                    new TaskStatuses { Name = nameof(Enumerations.TaskStatus.IN_PROGRESS).Replace("_", " "), Code = ((int)Enumerations.TaskStatus.IN_PROGRESS).ToString() },
                    new TaskStatuses { Name = nameof(Enumerations.TaskStatus.FINISHED), Code = ((int) Enumerations.TaskStatus.FINISHED).ToString() },
                    new TaskStatuses { Name = nameof(Enumerations.TaskStatus.CANCELLED), Code = ((int) Enumerations.TaskStatus.CANCELLED).ToString() }
                };

                UnitOfWork.TaskStatusesRepository.AddRange(taskStatuses);
                UnitOfWork.SaveChanges();
            }

            if (!hasCountries)
            {
                List<Countries> countries = new List<Countries>
                {
                    new Countries { Name = "Afghanistan", Iso = "AF" },
                    new Countries { Name = "Albania", Iso = "AL" },
                    new Countries { Name = "Algeria", Iso = "DZ" },
                    new Countries { Name = "Andorra", Iso = "AD" },
                    new Countries { Name = "Angola", Iso = "AO" },
                    new Countries { Name = "Antigua and Barbuda", Iso = "AG" },
                    new Countries { Name = "Argentina", Iso = "AR" },
                    new Countries { Name = "Armenia", Iso = "AM" },
                    new Countries { Name = "Australia", Iso = "AU" },
                    new Countries { Name = "Austria", Iso = "AT" },
                    new Countries { Name = "Azerbaijan", Iso = "AZ" },
                    new Countries { Name = "Bahamas", Iso = "BS" },
                    new Countries { Name = "Bahrain", Iso = "BH" },
                    new Countries { Name = "Bangladesh", Iso = "BD" },
                    new Countries { Name = "Barbados", Iso = "BB" },
                    new Countries { Name = "Belarus", Iso = "BY" },
                    new Countries { Name = "Belgium", Iso = "BE" },
                    new Countries { Name = "Belize", Iso = "BZ" },
                    new Countries { Name = "Benin", Iso = "BJ" },
                    new Countries { Name = "Bhutan", Iso = "BT" },
                    new Countries { Name = "Bolivia", Iso = "BO" },
                    new Countries { Name = "Bosnia and Herzegovina", Iso = "BA" },
                    new Countries { Name = "Botswana", Iso = "BW" },
                    new Countries { Name = "Brazil", Iso = "BR" },
                    new Countries { Name = "Brunei Darussalam", Iso = "BN" },
                    new Countries { Name = "Bulgaria", Iso = "BG" },
                    new Countries { Name = "Burkina Faso", Iso = "BF" },
                    new Countries { Name = "Burundi", Iso = "BI" },
                    new Countries { Name = "Cabo Verde", Iso = "CV" },
                    new Countries { Name = "Cambodia", Iso = "KH" },
                    new Countries { Name = "Cameroon", Iso = "CM" },
                    new Countries { Name = "Canada", Iso = "CA" },
                    new Countries { Name = "Central African Republic", Iso = "CF" },
                    new Countries { Name = "Chad", Iso = "TD" },
                    new Countries { Name = "Chile", Iso = "CL" },
                    new Countries { Name = "China", Iso = "CN" },
                    new Countries { Name = "Colombia", Iso = "CO" },
                    new Countries { Name = "Comoros", Iso = "KM" },
                    new Countries { Name = "Congo", Iso = "CG" },
                    new Countries { Name = "Congo (Democratic Republic)", Iso = "CD" },
                    new Countries { Name = "Costa Rica", Iso = "CR" },
                    new Countries { Name = "Croatia", Iso = "HR" },
                    new Countries { Name = "Cuba", Iso = "CU" },
                    new Countries { Name = "Cyprus", Iso = "CY" },
                    new Countries { Name = "Czech Republic", Iso = "CZ" },
                    new Countries { Name = "Denmark", Iso = "DK" },
                    new Countries { Name = "Djibouti", Iso = "DJ" },
                    new Countries { Name = "Dominica", Iso = "DM" },
                    new Countries { Name = "Dominican Republic", Iso = "DO" },
                    new Countries { Name = "Ecuador", Iso = "EC" },
                    new Countries { Name = "Egypt", Iso = "EG" },
                    new Countries { Name = "El Salvador", Iso = "SV" },
                    new Countries { Name = "Equatorial Guinea", Iso = "GQ" },
                    new Countries { Name = "Eritrea", Iso = "ER" },
                    new Countries { Name = "Estonia", Iso = "EE" },
                    new Countries { Name = "Eswatini", Iso = "SZ" },
                    new Countries { Name = "Ethiopia", Iso = "ET" },
                    new Countries { Name = "Fiji", Iso = "FJ" },
                    new Countries { Name = "Finland", Iso = "FI" },
                    new Countries { Name = "France", Iso = "FR" },
                    new Countries { Name = "Gabon", Iso = "GA" },
                    new Countries { Name = "Gambia", Iso = "GM" },
                    new Countries { Name = "Georgia", Iso = "GE" },
                    new Countries { Name = "Germany", Iso = "DE" },
                    new Countries { Name = "Ghana", Iso = "GH" },
                    new Countries { Name = "Greece", Iso = "GR" },
                    new Countries { Name = "Grenada", Iso = "GD" },
                    new Countries { Name = "Guatemala", Iso = "GT" },
                    new Countries { Name = "Guinea", Iso = "GN" },
                    new Countries { Name = "Guinea-Bissau", Iso = "GW" },
                    new Countries { Name = "Guyana", Iso = "GY" },
                    new Countries { Name = "Haiti", Iso = "HT" },
                    new Countries { Name = "Honduras", Iso = "HN" },
                    new Countries { Name = "Hungary", Iso = "HU" },
                    new Countries { Name = "Iceland", Iso = "IS" },
                    new Countries { Name = "India", Iso = "IN" },
                    new Countries { Name = "Indonesia", Iso = "ID" },
                    new Countries { Name = "Iran", Iso = "IR" },
                    new Countries { Name = "Iraq", Iso = "IQ" },
                    new Countries { Name = "Ireland", Iso = "IE" },
                    new Countries { Name = "Israel", Iso = "IL" },
                    new Countries { Name = "Italy", Iso = "IT" },
                    new Countries { Name = "Jamaica", Iso = "JM" },
                    new Countries { Name = "Japan", Iso = "JP" },
                    new Countries { Name = "Jordan", Iso = "JO" },
                    new Countries { Name = "Kazakhstan", Iso = "KZ" },
                    new Countries { Name = "Kenya", Iso = "KE" },
                    new Countries { Name = "Kiribati", Iso = "KI" },
                    new Countries { Name = "Korea (Democratic People's Republic)", Iso = "KP" },
                    new Countries { Name = "Korea (Republic)", Iso = "KR" },
                    new Countries { Name = "Kuwait", Iso = "KW" },
                    new Countries { Name = "Kyrgyzstan", Iso = "KG" },
                    new Countries { Name = "Lao People's Democratic Republic", Iso = "LA" },
                    new Countries { Name = "Latvia", Iso = "LV" },
                    new Countries { Name = "Lebanon", Iso = "LB" },
                    new Countries { Name = "Lesotho", Iso = "LS" },
                    new Countries { Name = "Liberia", Iso = "LR" },
                    new Countries { Name = "Libya", Iso = "LY" },
                    new Countries { Name = "Liechtenstein", Iso = "LI" },
                    new Countries { Name = "Lithuania", Iso = "LT" },
                    new Countries { Name = "Luxembourg", Iso = "LU" },
                    new Countries { Name = "Madagascar", Iso = "MG" },
                    new Countries { Name = "Malawi", Iso = "MW" },
                    new Countries { Name = "Malaysia", Iso = "MY" },
                    new Countries { Name = "Maldives", Iso = "MV" },
                    new Countries { Name = "Mali", Iso = "ML" },
                    new Countries { Name = "Malta", Iso = "MT" },
                    new Countries { Name = "Marshall Islands", Iso = "MH" },
                    new Countries { Name = "Mauritania", Iso = "MR" },
                    new Countries { Name = "Mauritius", Iso = "MU" },
                    new Countries { Name = "Mexico", Iso = "MX" },
                    new Countries { Name = "Micronesia (Federated States)", Iso = "FM" },
                    new Countries { Name = "Moldova", Iso = "MD" },
                    new Countries { Name = "Monaco", Iso = "MC" },
                    new Countries { Name = "Mongolia", Iso = "MN" },
                    new Countries { Name = "Montenegro", Iso = "ME" },
                    new Countries { Name = "Morocco", Iso = "MA" },
                    new Countries { Name = "Mozambique", Iso = "MZ" },
                    new Countries { Name = "Myanmar", Iso = "MM" },
                    new Countries { Name = "Namibia", Iso = "NA" },
                    new Countries { Name = "Nauru", Iso = "NR" },
                    new Countries { Name = "Nepal", Iso = "NP" },
                    new Countries { Name = "Netherlands", Iso = "NL" },
                    new Countries { Name = "New Zealand", Iso = "NZ" },
                    new Countries { Name = "Nicaragua", Iso = "NI" },
                    new Countries { Name = "Niger", Iso = "NE" },
                    new Countries { Name = "Nigeria", Iso = "NG" },
                    new Countries { Name = "North Macedonia", Iso = "MK" },
                    new Countries { Name = "Norway", Iso = "NO" },
                    new Countries { Name = "Oman", Iso = "OM" },
                    new Countries { Name = "Pakistan", Iso = "PK" },
                    new Countries { Name = "Palau", Iso = "PW" },
                    new Countries { Name = "Palestine", Iso = "PS" },
                    new Countries { Name = "Panama", Iso = "PA" },
                    new Countries { Name = "Papua New Guinea", Iso = "PG" },
                    new Countries { Name = "Paraguay", Iso = "PY" },
                    new Countries { Name = "Peru", Iso = "PE" },
                    new Countries { Name = "Philippines", Iso = "PH" },
                    new Countries { Name = "Poland", Iso = "PL" },
                    new Countries { Name = "Portugal", Iso = "PT" },
                    new Countries { Name = "Qatar", Iso = "QA" },
                    new Countries { Name = "Romania", Iso = "RO" },
                    new Countries { Name = "Russian Federation", Iso = "RU" },
                    new Countries { Name = "Rwanda", Iso = "RW" },
                    new Countries { Name = "Saint Kitts and Nevis", Iso = "KN" },
                    new Countries { Name = "Saint Lucia", Iso = "LC" },
                    new Countries { Name = "Saint Vincent and the Grenadines", Iso = "VC" },
                    new Countries { Name = "Samoa", Iso = "WS" },
                    new Countries { Name = "San Marino", Iso = "SM" },
                    new Countries { Name = "Sao Tome and Principe", Iso = "ST" },
                    new Countries { Name = "Saudi Arabia", Iso = "SA" },
                    new Countries { Name = "Senegal", Iso = "SN" },
                    new Countries { Name = "Serbia", Iso = "RS" },
                    new Countries { Name = "Seychelles", Iso = "SC" },
                    new Countries { Name = "Sierra Leone", Iso = "SL" },
                    new Countries { Name = "Singapore", Iso = "SG" },
                    new Countries { Name = "Slovakia", Iso = "SK" },
                    new Countries { Name = "Slovenia", Iso = "SI" },
                    new Countries { Name = "Solomon Islands", Iso = "SB" },
                    new Countries { Name = "Somalia", Iso = "SO" },
                    new Countries { Name = "South Africa", Iso = "ZA" },
                    new Countries { Name = "South Sudan", Iso = "SS" },
                    new Countries { Name = "Spain", Iso = "ES" },
                    new Countries { Name = "Sri Lanka", Iso = "LK" },
                    new Countries { Name = "Sudan", Iso = "SD" },
                    new Countries { Name = "Suriname", Iso = "SR" },
                    new Countries { Name = "Sweden", Iso = "SE" },
                    new Countries { Name = "Switzerland", Iso = "CH" },
                    new Countries { Name = "Syria", Iso = "SY" },
                    new Countries { Name = "Tajikistan", Iso = "TJ" },
                    new Countries { Name = "Tanzania", Iso = "TZ" },
                    new Countries { Name = "Thailand", Iso = "TH" },
                    new Countries { Name = "Timor-Leste", Iso = "TL" },
                    new Countries { Name = "Togo", Iso = "TG" },
                    new Countries { Name = "Tonga", Iso = "TO" },
                    new Countries { Name = "Trinidad and Tobago", Iso = "TT" },
                    new Countries { Name = "Tunisia", Iso = "TN" },
                    new Countries { Name = "Turkey", Iso = "TR" },
                    new Countries { Name = "Turkmenistan", Iso = "TM" },
                    new Countries { Name = "Tuvalu", Iso = "TV" },
                    new Countries { Name = "Uganda", Iso = "UG" },
                    new Countries { Name = "Ukraine", Iso = "UA" },
                    new Countries { Name = "United Arab Emirates", Iso = "AE" },
                    new Countries { Name = "United Kingdom", Iso = "GB" },
                    new Countries { Name = "United States of America", Iso = "US" },
                    new Countries { Name = "Uruguay", Iso = "UY" },
                    new Countries { Name = "Uzbekistan", Iso = "UZ" },
                    new Countries { Name = "Vanuatu", Iso = "VU" },
                    new Countries { Name = "Venezuela", Iso = "VE" },
                    new Countries { Name = "Vietnam", Iso = "VN" },
                    new Countries { Name = "Yemen", Iso = "YE" },
                    new Countries { Name = "Zambia", Iso = "ZM" },
                    new Countries { Name = "Zimbabwe", Iso = "ZW" }
                };

                UnitOfWork.CountriesRepository.AddRange(countries);
                UnitOfWork.SaveChanges();
            }

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

            if(!hasAbsenceTypes)
            {
                List<AbsenceTypes> absenceTypes = new List<AbsenceTypes>
                {
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.SICK_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.SICK_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.VACATION_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.VACATION_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.PERSONAL_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.PERSONAL_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.PARENTAL_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.PARENTAL_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.BEREAVEMENT_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.BEREAVEMENT_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.JURY_DUTY).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.JURY_DUTY).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.MILITARY_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.MILITARY_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.UNPAID_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.UNPAID_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.PUBLIC_HOLIDAY).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.PUBLIC_HOLIDAY).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.STUDY_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.STUDY_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.SABBATICAL).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.SABBATICAL).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.COMPENSATORY_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.COMPENSATORY_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.VOLUNTEER_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.VOLUNTEER_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.FAMILY_AND_MEDICAL_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.FAMILY_AND_MEDICAL_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.HALF_DAY_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.HALF_DAY_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.EMERGENCY_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.EMERGENCY_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.CASUAL_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.CASUAL_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.ADMINISTRATIVE_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.ADMINISTRATIVE_LEAVE).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.FLOATING_HOLIDAY).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.FLOATING_HOLIDAY).ToString() },
                    new AbsenceTypes { Name = nameof(Enumerations.AbsenceType.RELIGIOUS_LEAVE).Replace("_", " "), Code = ((int) Enumerations.AbsenceType.RELIGIOUS_LEAVE).ToString() }
                };

                UnitOfWork.AbsenceTypesRepository.AddRange(absenceTypes);
                UnitOfWork.SaveChanges();
            }
        }
    }
}
