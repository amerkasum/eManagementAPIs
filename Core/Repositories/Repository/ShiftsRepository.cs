using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class ShiftsRepository : Repository<Shifts>, IShiftsRepository
    {
        public ShiftsRepository(ApplicationDbContext context) : base(context) { }

        public List<SelectListHelper> GetSelectLists()
        {
            var result = _context.Shifts.Select(x => new SelectListHelper
            {
                Id = x.Id,
                Name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.Name.ToLower()),
                Code = x.Code
            }).ToList();

            return result;
        }
    }
}
