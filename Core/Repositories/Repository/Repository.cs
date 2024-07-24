using Core.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DatabaseContext;

namespace Core.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        public MyContext _context;
        private DbSet<T> table;

        public Repository()
        {
            this._context = new MyContext();
            table = _context.Set<T>();
        }

        public Repository(MyContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        //Add
        public virtual void Add(T t) => table.Add(t);

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
                table.AddRange(entities);
                return entities;
            }
            catch
            {
                throw;
            }

        }

        //GetAll
        public virtual IEnumerable<T> GetAll() => table.AsNoTracking().Where(x => !x.IsDeleted);

        //GetById
        public virtual T GetById(int Id) => table.Find(Id);
        public virtual async Task<T> GetByIdAsync(int Id) => await table.FindAsync(Id);



        //Remove
        public virtual void RemoveById(int Id, bool softDelete = true)
        {
            T result = table.FirstOrDefault(x => x.Id.Equals(Id)); //razlika equals i ==
            try
            {
                if (softDelete)
                {
                    result.IsDeleted = true;
                    table.Update(result);
                }
                else
                {
                    table.Remove(result);
                }
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> RemoveRange(IEnumerable<T> entities, bool softDelete = true)
        {
            try
            {
                if (softDelete)
                {
                    foreach (var i in entities)
                    {
                        i.IsDeleted = true;
                    }
                    table.UpdateRange(entities);
                }
                else
                {
                    table.RemoveRange(entities);
                }
            }
            catch
            {
                throw;
            }
            return entities;
        }

        public virtual IEnumerable<T> RemoveRangeByIds(int[] ids, bool softDelete = true)
        {
            try
            {
                var entities = table.Where(x => ids.Contains(x.Id));
                return this.RemoveRange(entities, softDelete);
            }
            catch
            {
                throw;
            }

        }

        public T Remove(T entity, bool softDelete = true)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                var itemToDelete = table.FirstOrDefault(x => x.Id == entity.Id);
                if (softDelete)
                {
                    itemToDelete.IsDeleted = true;
                    table.Update(itemToDelete);
                }
                else table.Remove(itemToDelete);
                return itemToDelete;
            }
            catch
            {
                throw;
            }

        }

        //Update
        public virtual void Update(T t)
        {
            try
            {
                table.Attach(t);
                _context.Entry(t).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }

        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                if (entities != null)
                    table.UpdateRange(entities);
            }
            catch
            {
                throw;
            }

        }

        //async metode


        public async Task AddASync(T t)
        {
            await table.AddAsync(t);
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
                await table.AddRangeAsync(entities);
                return entities;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> RemoveRangeByIdsAsync(int[] ids, bool softDelete = true)
        {
            try
            {
                var entities = await table.Where(x => ids.Contains(x.Id)).ToListAsync();
                return this.RemoveRange(entities, softDelete);
            }
            catch
            {
                throw;
            }
        }

        public async Task RemoveByIdAsync(int Id, bool softDelete)
        {
            var result = await table.FirstOrDefaultAsync(x => x.Id.Equals(Id)); //razlika equals i ==
            try
            {
                if (softDelete)
                {
                    result.IsDeleted = true;
                    table.Update(result);
                }
                else
                {
                    table.Remove(result);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task RemoveAsync(T entity, bool softDelete)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                var itemToDelete = await table.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (softDelete)
                {
                    itemToDelete.IsDeleted = true;
                    table.Update(itemToDelete);
                }
                else table.Remove(itemToDelete);
            }
            catch
            {
                throw;
            }
        }


        //GetAll queriable, ienumerable, list
        public async Task<IEnumerable<T>> GetAllAsync() => await table.AsNoTracking().Where(x => !x.IsDeleted).ToListAsync();
        public IQueryable<T> GetAllAsQueryable()
        {
            return table.AsNoTracking().Where(x => !x.IsDeleted ).AsQueryable();
        }

        public async Task<List<T>> GetAllAsListAsync()
        {
            return await table.AsNoTracking().Where(x => !x.IsDeleted).ToListAsync();
        }

        public List<T> GetAllAsList()
        {
            return table.AsNoTracking().Where(x => !x.IsDeleted).ToList();
        }
    }
}
