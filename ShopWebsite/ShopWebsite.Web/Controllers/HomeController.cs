using ShopWebsite.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ShopWebsite.Data.Services.Interfaces;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Product;
using ShopWebsite.Model.Entities.User;

namespace ShopWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUnitService _unitService;
        private readonly ICurrencyService _currencyService;
        private readonly IEmployeeService _employeeService;

        public HomeController(IProductService productService, IUnitService unitService, ICurrencyService currencyService,
            IEmployeeService employeeService)
        {
            _productService = productService;
            _unitService = unitService;
            _currencyService = currencyService;
            _employeeService = employeeService;
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

        public ActionResult Employees()
        {
            TransactionalInformation tr;
            List<Employee> list = _employeeService.GetAllMenById(employee => true, 1, 10, false, out tr).ToList();
            return View(list);
        }

        public ActionResult Dis()
        {
            TransactionalInformation tr;
            List<ProductDiscount> list = _productService.GetAllDiscountsOfProduct(1, out tr).ToList();
            return View(list);
        }
    }
}