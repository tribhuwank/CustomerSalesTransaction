using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSalesTransaction.Common
{
    public class SalesTransaction
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public string EnterdBy{ get; set; }
        public DateTime EnteredDate { get; set; }

}
}
