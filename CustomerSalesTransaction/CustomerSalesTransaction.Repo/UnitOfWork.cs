using CustomerSalesTransaction.Common;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSalesTransaction.Repo
{
    internal class UnitOfWork:IUnitOfWork
    {
        private readonly SalesDBContext _context;      
        public UnitOfWork(SalesDBContext context)
        {            
            _context = context;
            Customers = new CustomerRepository(context);
            Products = new ProductRepository(context);
            SalesTransactions=new SalesTransactionsRepository(context);
            Invoices = new InvoiceRepository(context);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public ICustomerRepository Customers { get; private set; }

        public IProductRepository Products{ get; private set; }

        public ISalesTransactionRepository SalesTransactions { get; private set; }       

        public IInvoiceRepository Invoices { get; private set; }
        

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
