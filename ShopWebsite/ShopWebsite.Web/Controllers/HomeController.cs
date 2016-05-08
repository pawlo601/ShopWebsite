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
        private readonly IUnitService _unitService;
        private readonly ICurrencyService _currencyService;

        public HomeController(IProductService productService, IUnitService unitService, ICurrencyService currencyService)
        {
            _productService = productService;
            _unitService = unitService;
            _currencyService = currencyService;
        }

        // GET: Home
        public ActionResult Index()
        {
            TransactionalInformation tr = new TransactionalInformation();
            List<Product> list = _productService.GetAllProducts(product => true, 1, 10, product =>  (IComparable)(product.Id), true,
                out tr).ToList();
            return View(list);
        }
    }
}