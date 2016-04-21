using ShopWebsite.Data.Services.Interfaces;
using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }

        // GET: Home
        public ActionResult Index()
        {
            int total;
            TransactionalInformation ti;
            List<Product> all = _productService.GetAllProducts(1, 12, "quantity", true, "", out total, out ti).ToList();

            return View(all);
        }
    }
}