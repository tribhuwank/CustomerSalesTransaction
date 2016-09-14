using CustomerSalesTransaction.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSalesTransaction.Repo
{
    public class ProductRepository:IProductRepository
    {
        
        private readonly SalesDBContext Context;       
        public ProductRepository(SalesDBContext context)             
        {             
            Context = context ?? new SalesDBContext();
        }

        public Task AddAsync(Product entity)
        {
            var task = new Task(() =>
            {
                Context.set<Product>().Add(entity);
            });
            task.Start();
            return task;
        }

        public Task AddRangeAsync(IEnumerable<Product> entities)
        {
            var task = new Task(() =>
            {
                foreach(var entity in entities)
                {
                    Context.set<Product>().Add(entity);
                }               
            });
            task.Start();
            return task;
        }

        public Task DeleteAsync(int id)
        {
            var task = new Task(async () =>
            {
                Context.set<Product>().Remove(await this.GetByIdAsync(id));
            });
            task.Start();
            return task;
        }

        public Task DeleteAsync(Product entity)
        {
            var task = new Task(() =>
            {
                Context.set<Product>().Remove(entity);
            });
            task.Start();
            return task;
        }

        public Task DeleteRangeAsync(IEnumerable<Product> entities)
        {
            var task = new Task(() =>
            {
                foreach (var entity in entities)
                {
                    Context.set<Product>().Remove(entity);
                }
            });
            task.Start();
            return task;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            var task = new Task<IEnumerable<Product>>(() =>
            {
                dynamic result = Context.set<Product>().Select(x => x).ToListAsync();
                return result;
            });
            task.Start();

            return task;
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var task = new Task<Product>(() =>
            {
                dynamic result = Context.set<Product>().Find(id);
                return result;
            });
            task.Start();

            return task;
        }
    }
}
