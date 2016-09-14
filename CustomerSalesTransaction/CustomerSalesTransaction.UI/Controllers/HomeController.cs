using CustomerSalesTransaction.Common;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomerSalesTransaction.UI.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork unitOfWork;
        public HomeController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GetSalesTransction()
        {
            string result = await unitOfWork.SalesTransactions.GetSalesTransction();
            return PartialView(result);
        }
    }
}