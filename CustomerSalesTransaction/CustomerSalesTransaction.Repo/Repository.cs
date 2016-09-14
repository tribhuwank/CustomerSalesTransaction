using CustomerSalesTransaction.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSalesTransaction.Repo
{
    internal class Repository<T> : IRepositiry<T> where T:class
    {
        protected readonly DbContext Context;

        private readonly DbSet<T> _dbSet;
        public Repository(DbContext context)
        {
            this.Context = context;
            _dbSet = Context.Set<T>();
        }

        public Task AddAsync(T entity)
        {
            var task = new Task(() =>
            {
                dynamic result = _dbSet.Add(entity);                
            });
            task.Start();
            return task;          
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            var task = new Task(() =>
            {
                dynamic result = _dbSet.AddRange(entities);
            });
            task.Start();
            return task;
        }

        public Task DeleteAsync(int id)
        {
            var task = new Task(async () =>
            {
                dynamic result = _dbSet.Remove(await this.GetByIdAsync(id));
            });
            task.Start();
            return task;
        }

        public Task DeleteAsync(T entity)
        {
            var task = new Task(() =>
            {
                dynamic result = _dbSet.Remove(entity);
            });
            task.Start();
            return task;
        }

        public Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            var task = new Task(() =>
            {
                dynamic result = _dbSet.RemoveRange(entities);
            });
            task.Start();
            return task;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            var task = new Task<IEnumerable<T>>(() =>
            {
                dynamic result = _dbSet.Select(x => x).ToListAsync();
                return result;
            });
            task.Start();
           
            return  task;
        }

        public Task<T> GetByIdAsync(int id)
        {
            var task = new Task<T>(() =>
            {
                dynamic result = _dbSet.FindAsync(id);
                return result;
            });
            task.Start();

            return task;
        }
        protected DbSet<T> DbSet
        {
            get
            {
                return Context.Set<T>();
            }
        }
        //public IEnumerable<T> GetAll()
        //{
        //    return _dbSet.ToList();
        //}

        //public T GetById(int id)
        //{
        //    return _dbSet.Find(id);
        //}

        //public void Add(T entity)
        //{
        //    _dbSet.Add(entity);
        //}

        //public void AddRange(IEnumerable<T> entities)
        //{
        //    _dbSet.AddRange(entities);
        //}
        //public async Task  Delete(T entity)
        //{
        //    await _dbSet.Remove(entity);
        //}
        //public void DeleteRange(IEnumerable<T> entities)
        //{
        //    _dbSet.RemoveRange(entities);
        //}
        //public void Delete(int id)
        //{
        //    _dbSet.Remove(this.GetById(id));
        //}
    }
}
