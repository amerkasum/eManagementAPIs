using Core.Repositories.Repository;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Entities
        //TODO
        UsersRepository UsersRepository { get; }
        CountriesRepository CountriesRepository { get; }
        CitiesRepository CitiesRepository { get; }
        UserLoggerRepository UserLoggerRepository { get; }
        #endregion


        int Complete();
        Task CompleteAsync();
        void BeginTransaction();
        void Commit();
        void RollBack();
        void Dispose();
    }
}
