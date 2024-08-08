using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories.Repository
{
    public class TaskReviewRepository : Repository<TaskReview>, ITaskReviewRepository
    {
        public TaskReviewRepository(ApplicationDbContext context) : base(context) { }
    }
}
