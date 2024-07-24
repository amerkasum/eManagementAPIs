﻿using Core.DatabaseContext;
using Core.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyContext _context;
        //TODO
        public UsersRepository UsersRepository => new UsersRepository(_context);
        public CountriesRepository CountriesRepository => new CountriesRepository(_context);
        public CitiesRepository CitiesRepository => new CitiesRepository(_context);
        public UserLoggerRepository UserLoggerRepository => new UserLoggerRepository(_context);

        public UnitOfWork(MyContext context)
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

        public int Complete()
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
