using System.Threading.Tasks;

namespace CustomerSalesTransaction.Common
{

    public interface ISalesTransactionRepository : IRepositiry<SalesTransaction>
    {
        Task<string> GetSalesTransction();
    }
}
