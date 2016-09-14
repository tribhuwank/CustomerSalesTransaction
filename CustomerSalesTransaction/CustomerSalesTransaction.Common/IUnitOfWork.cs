using System;

namespace CustomerSalesTransaction.Common
{
    public interface IUnitOfWork : IDisposable
    {
        // Save pending changes to the data store.
        void Commit();
        // Repositories
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        ISalesTransactionRepository SalesTransactions { get; }
        IInvoiceRepository Invoices { get; }

    }
}
