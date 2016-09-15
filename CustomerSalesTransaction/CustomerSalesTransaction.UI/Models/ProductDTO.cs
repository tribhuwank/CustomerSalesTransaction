using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSalesTransaction.UI.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public double BasePrice { get; set; }
        public double ListPrice { get; set; }
        public int TotalStock { get; set; }
    }
}