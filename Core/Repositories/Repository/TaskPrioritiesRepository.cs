using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories.Repository
{
    public class TaskPrioritiesRepository : Repository<TaskPriorities>, ITaskPrioritiesRepository
    {
        public TaskPrioritiesRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public List<SelectListHelper> GetSelectLists()
        {
            var result = _context.TaskPriorities.Select(x => new SelectListHelper
            {
                Id = x.Id,
                Name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.Name.ToLower()),
                Code = x.Code
            }).ToList();

            return result;
        }

    }
}
