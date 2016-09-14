using CustomerSalesTransaction.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace CustomerSalesTransaction.Repo
{
    public class SalesTransactionsRepository: ISalesTransactionRepository
    {
        private readonly SalesDBContext Context;
        public SalesTransactionsRepository(SalesDBContext context)
        {
            Context = context ?? new SalesDBContext();
        }

        public Task AddAsync(SalesTransaction entity)
        {
            var task = new Task(() =>
            {
                Context.set<SalesTransaction>().Add(entity);
            });
            task.Start();
            return task;
        }

        public Task AddRangeAsync(IEnumerable<SalesTransaction> entities)
        {
            var task = new Task(() =>
            {
                foreach (var entity in entities)
                {
                    Context.set<SalesTransaction>().Add(entity);
                }
            });
            task.Start();
            return task;
        }

        public Task DeleteAsync(int id)
        {
            var task = new Task(async () =>
            {
                Context.set<SalesTransaction>().Remove(await this.GetByIdAsync(id));
            });
            task.Start();
            return task;
        }

        public Task DeleteAsync(SalesTransaction entity)
        {
            var task = new Task(() =>
            {
                Context.set<SalesTransaction>().Remove(entity);
            });
            task.Start();
            return task;
        }

        public Task DeleteRangeAsync(IEnumerable<SalesTransaction> entities)
        {
            var task = new Task(() =>
            {
                foreach (var entity in entities)
                {
                    Context.set<SalesTransaction>().Remove(entity);
                }
            });
            task.Start();
            return task;
        }

        public Task<IEnumerable<SalesTransaction>> GetAllAsync()
        {
            var task = new Task<IEnumerable<SalesTransaction>>(() =>
            {
                dynamic result = Context.set<SalesTransaction>().Select(x => x).ToListAsync();
                return result;
            });
            task.Start();

            return task;
        }

        public Task<SalesTransaction> GetByIdAsync(int id)
        {
            var task = new Task<SalesTransaction>(() =>
            {
                dynamic result = Context.set<SalesTransaction>().Find(id);
                return result;
            });
            task.Start();

            return task;
        }

        Task<string> ISalesTransactionRepository.GetSalesTransction()
        {
            var task = new Task<string>(() =>
            {
                dynamic result =Context.Database.SqlQuery<string>("EXEC GetSalesTransactions");
                return Convert.ToString(result);
            });
            task.Start();

            return task;
        }
    }
}
