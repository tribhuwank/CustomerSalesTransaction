using CustomerSalesTransaction.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace CustomerSalesTransaction.Repo
{
    public class CustomerRepository : ICustomerRepository
    {
         private readonly SalesDBContext Context;
         public CustomerRepository(SalesDBContext context)             
        {

            Context = context ?? new SalesDBContext();
        }

        public Task AddAsync(Customer entity)
        {
            var task = new Task(() =>
            {
                Context.set<Customer>().Add(entity);
            });
            task.Start();
            return task;
        }

        public Task AddRangeAsync(IEnumerable<Customer> entities)
        {
            var task = new Task(() =>
            {
                foreach (var entity in entities)
                {
                    Context.set<Customer>().Add(entity);
                }
            });
            task.Start();
            return task;
        }

        public Task DeleteAsync(int id)
        {
            var task = new Task(async () =>
            {
                Context.set<Customer>().Remove(await this.GetByIdAsync(id));
            });
            task.Start();
            return task;
        }

        public Task DeleteAsync(Customer entity)
        {
            var task = new Task(() =>
            {
                Context.set<Customer>().Remove(entity);
            });
            task.Start();
            return task;
        }

        public Task DeleteRangeAsync(IEnumerable<Customer> entities)
        {
            var task = new Task(() =>
            {
                foreach (var entity in entities)
                {
                    Context.set<Customer>().Remove(entity);
                }
            });
            task.Start();
            return task;
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            var task = new Task<IEnumerable<Customer>>(() =>
            {
                dynamic result = Context.set<Customer>().Select(x => x).ToListAsync();
                return result;
            });
            task.Start();

            return task;
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            var task = new Task<Customer>(() =>
            {
                dynamic result = Context.set<Customer>().Find(id);
                return result;
            });
            task.Start();

            return task;
        }
        
    }
}
