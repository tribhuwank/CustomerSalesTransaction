using CustomerSalesTransaction.Common;
using CustomerSalesTransaction.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CustomerSalesTransaction.UI.Areas.Product.Controllers
{
    public class ProductController : Controller
    {
        IUnitOfWork unitOfWork;
        public ProductController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        // GET: Product/Product
        public ActionResult Index()
        {
            ViewBag.HtmlOutput = this.GetProductTable();
            return View();
        }

        // GET: Product/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Product/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProductDTO product, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                await unitOfWork.Products.AddAsync((product.Convert()));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetProductTable()
        {
            string result = string.Empty;
            result = await unitOfWork.SalesTransactions.GetSalesTransction();
            return Content(result);
        }
    }
}
