using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSalesTransaction.Common
{
    public class Invoice
    {
        public int Id { get; set; }
        public int InvoiceNo { get; set; }
        public int CustomerId { get; set; }
        public int SalesTransactionId { get; set; }
        public string EnteredBy { get; set; }
        public DateTime EnteredDate { get; set; }

    }
}
