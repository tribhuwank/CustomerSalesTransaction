using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CustomerSalesTransaction.Common
{
    public partial class SalesDBContext:DbContext
    {          
      public SalesDBContext() :
            base("SalesDB") //Add connection string from Appconfig.
        {
           
        }
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
          modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
          modelBuilder.Entity<Product>().HasKey(c => c.Id);
          modelBuilder.Entity<Customer>().HasKey(c => c.Id);
        }
      public IDbSet<T> set<T>() where T : class
      {
          return base.Set<T>();
      }     
    
    }
}
