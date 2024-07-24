using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.Repository
{
    public class RolesReporitory : Repository<Roles>, IRolesReporitory
    {
        public RolesReporitory(MyContext context) : base(context)
        {
        }
    }
}