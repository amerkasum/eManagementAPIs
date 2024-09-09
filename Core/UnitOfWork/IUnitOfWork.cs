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
        EventsRepository EventsRepository { get; }
        EventStatusesRepository EventStatusesRepository { get; }
        TaskStatusesRepository TaskStatusesRepository { get; }
        RolesReporitory RolesRepository { get; }
        UserRolesRepository UserRolesRepository { get; }
        ShiftsRepository ShiftsRepository { get; }
        AbsenceTypesRepository AbsenceTypesRepository { get; }
        WorkingAbsencesRepository WorkingAbsencesRepository { get; }
        WorkingDaysRepository WorkingDaysRepository { get; }
        UserResidenceRepository UserResidenceRepository { get; }
        TasksRepository TasksRepository { get; }
        UserTasksRepository UserTasksRepository { get; }
        TaskReviewRepository TaskReviewRepository { get; }
        PositionsRepository PositionsRepository { get; }
        UserPositionsRepository UserPositionsRepository { get; }
        ContractTypeRepository ContractTypeRepository { get; }
        TaskPrioritiesRepository TaskPrioritiesRepository { get; }
        AbsenceStatusRepository AbsenceStatusRepository { get; }
        #endregion

        int SaveChanges();
        Task CompleteAsync();
        void BeginTransaction();
        void Commit();
        void RollBack();
        void Dispose();
    }
}
