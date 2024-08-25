using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Entities;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class PositionsRepository : Repository<Positions>, IPositionsRepository
    {
        public PositionsRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public List<SelectListHelper> GetSelectLists()
        {
            var result = _context.Positions.Select(x => new SelectListHelper
            {
                Id = x.Id,
                Name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.Name.ToLower()),
                Code = x.Code
            }).ToList();

            return result;
        }
    }
}
