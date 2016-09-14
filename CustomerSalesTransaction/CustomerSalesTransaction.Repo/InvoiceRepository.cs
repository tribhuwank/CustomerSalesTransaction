using CustomerSalesTransaction.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSalesTransaction.Repo
{
    public class InvoiceRepository: IInvoiceRepository
    {
        private readonly SalesDBContext Context;
        public InvoiceRepository(SalesDBContext context)
        {
            Context = context ?? new SalesDBContext();
        }
        public Task AddAsync(Invoice entity)
        {
            var task = new Task(() =>
            {
                Context.set<Invoice>().Add(entity);
            });
            task.Start();
            return task;
        }

        public Task AddRangeAsync(IEnumerable<Invoice> entities)
        {
            var task = new Task(() =>
            {
                foreach (var entity in entities)
                {
                    Context.set<Invoice>().Add(entity);
                }
            });
            task.Start();
            return task;
        }

        public Task DeleteAsync(int id)
        {
            var task = new Task(async () =>
            {
                Context.set<Invoice>().Remove(await this.GetByIdAsync(id));
            });
            task.Start();
            return task;
        }

        public Task DeleteAsync(Invoice entity)
        {
            var task = new Task(() =>
            {
                Context.set<Invoice>().Remove(entity);
            });
            task.Start();
            return task;
        }

        public Task DeleteRangeAsync(IEnumerable<Invoice> entities)
        {
            var task = new Task(() =>
            {
                foreach (var entity in entities)
                {
                    Context.set<Invoice>().Remove(entity);
                }
            });
            task.Start();
            return task;
        }

        public Task<IEnumerable<Invoice>> GetAllAsync()
        {
            var task = new Task<IEnumerable<Invoice>>(() =>
            {
                dynamic result = Context.set<Invoice>().Select(x => x).ToListAsync();
                return result;
            });
            task.Start();

            return task;
        }

        public Task<Invoice> GetByIdAsync(int id)
        {
            var task = new Task<Invoice>(() =>
            {
                dynamic result = Context.set<Invoice>().Find(id);
                return result;
            });
            task.Start();

            return task;
        }
    }
}
