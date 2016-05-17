using ShopWebsite.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ShopWebsite.Data.Services.Interfaces.ProductServiceInterfaces;
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
            return View();
        }

        public ActionResult Units()
        {
            TransactionalInformation tr;
            List<Unit> list = _unitService.GetAllUnitsById(a => true, 1, 10, true, out tr).ToList();
            return View(list);
        }

        public ActionResult Products()
        {
            TransactionalInformation tr;
            List<Product> list = _productService.GetAllProductsById(product => true, 1, 5, false, out tr).ToList();
            return View(list);
        }

        public ActionResult Curriencies()
        {
            TransactionalInformation tr;
            List<Currency> list = _currencyService.GetAllCurrenciesById(currency => true, 1, 10, true, out tr).ToList();
            return View(list);
        }
    }
}