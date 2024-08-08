using Core.DatabaseContext;
using Core.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        //TODO
        public UsersRepository UsersRepository => new UsersRepository(_context);
        public CountriesRepository CountriesRepository => new CountriesRepository(_context);
        public CitiesRepository CitiesRepository => new CitiesRepository(_context);
        public UserLoggerRepository UserLoggerRepository => new UserLoggerRepository(_context);
        public EventsRepository EventsRepository => new EventsRepository(_context);
        public EventStatusesRepository EventStatusesRepository => new EventStatusesRepository(_context);
        public TaskStatusesRepository TaskStatusesRepository => new TaskStatusesRepository(_context);
        public RolesReporitory RolesRepository => new RolesReporitory(_context);
        public UserRolesRepository UserRolesRepository => new UserRolesRepository(_context);
        public ShiftsRepository ShiftsRepository => new ShiftsRepository(_context);
        public AbsenceTypesRepository AbsenceTypesRepository => new AbsenceTypesRepository(_context);
        public WorkingAbsencesRepository WorkingAbsencesRepository => new WorkingAbsencesRepository(_context);
        public WorkingDaysRepository WorkingDaysRepository => new WorkingDaysRepository(_context);
        public UserResidenceRepository UserResidenceRepository => new UserResidenceRepository(_context);
        public TasksRepository TasksRepository => new TasksRepository(_context);
        public UserTasksRepository UserTasksRepository => new UserTasksRepository(_context);
        public TaskReviewRepository TaskReviewRepository => new TaskReviewRepository(_context);

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        //begin, commit, rollback ----> implementirati

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
            _context.Dispose();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
