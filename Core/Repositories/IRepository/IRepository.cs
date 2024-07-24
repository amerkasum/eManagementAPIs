using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.IRepository
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T t);
        Task AddASync(T t);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        //GetById
        Task<T> GetByIdAsync(int Id);
        T GetById(int Id);

        //Remove
        void RemoveById(int id, bool softDelete = true);
        Task RemoveByIdAsync(int id, bool softDelete = true);
        T Remove(T entity, bool softDelete = true);
        Task RemoveAsync(T entity, bool softDelete = true);
        IEnumerable<T> RemoveRangeByIds(int[] ids, bool softDelete = true);
        Task<IEnumerable<T>> RemoveRangeByIdsAsync(int[] ids, bool softDelete = true);
        IEnumerable<T> RemoveRange(IEnumerable<T> entities, bool softDelete = true);

        //Update
        void Update(T t);
        void UpdateRange(IEnumerable<T> entities);

    }
}
