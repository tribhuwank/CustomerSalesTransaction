using CustomerSalesTransaction.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerSalesTransaction.Common;

namespace CustomerSalesTransaction.UI
{
    public static class Utility
    {
        internal static Product Convert(this ProductDTO product)
        {
            return new Product() {Id=product.Id, BasePrice = product.BasePrice, Description = product.Description, ListPrice = product.ListPrice, Name = product.Name, TotalStock = product.TotalStock, Type = product.Type };
        }
        internal static Customer Convert(this CustomerDTO customer)
        {
            return new Customer() {Id=customer.Id,Address= customer.Address,City=customer.City,Name=customer.Name,Email=customer.Email,Fax=customer.Fax,Gender=customer.Gender,Phone=customer.Phone,State=customer.State };
        }
    }
}