using ShopWebsite.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ShopWebsite.Data.Services.Interfaces;
using ShopWebsite.Data.Services.Interfaces.Audit;
using ShopWebsite.Data.Services.Interfaces.Log;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Product;
using ShopWebsite.Model.Entities.User;
using ShopWebsite.Web.Models;
using Action = ShopWebsite.Model.Entities.Audit.Action;

namespace ShopWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUnitService _unitService;
        private readonly ICurrencyService _currencyService;
        private readonly IEmployeeService _employeeService;
        private readonly ILogService _logService;
        private readonly IAuditService AuditService;
        private readonly AuditAction _auditAction;

        public HomeController(IProductService productService, IUnitService unitService, ICurrencyService currencyService,
            IEmployeeService employeeService, ILogService logService, IAuditService auditService)
        {
            _productService = productService;
            _unitService = unitService;
            _currencyService = currencyService;
            _employeeService = employeeService;
            _logService = logService;
            AuditService = auditService;
            _auditAction = new AuditAction(auditService);
        }

        // GET: Home
        public ActionResult Index()
        {
            _auditAction.Report(HttpContext, 1, Action.Show, string.Empty, string.Empty);
            return View();
        }

        public ActionResult Units()
        {
            _auditAction.Report(HttpContext, 2, Action.Show, string.Empty, string.Empty);
            TransactionalInformation tr;
            List<Unit> list = _unitService.GetAllUnitsById(a => true, 1, 10, true, out tr).ToList();
            return View(list);
        }

        public ActionResult Products()
        {
            _auditAction.Report(HttpContext, 3, Action.Show, string.Empty, string.Empty);
            TransactionalInformation tr;
            List<Product> list = _productService.GetAllProductsById(product => true, 1, 5, false, out tr).ToList();
            return View(list);
        }

        public ActionResult Curriencies()
        {
            _auditAction.Report(HttpContext, 1, Action.Show, string.Empty, string.Empty);
            TransactionalInformation tr;
            List<Currency> list = _currencyService.GetAllCurrenciesById(currency => true, 1, 10, true, out tr).ToList();
            return View(list);
        }

        public ActionResult Employees()
        {
            _auditAction.Report(HttpContext, 2, Action.Show, string.Empty, string.Empty);
            TransactionalInformation tr;
            List<Employee> list = _employeeService.GetAllMenById(employee => true, 1, 10, false, out tr).ToList();
            return View(list);
        }

        public ActionResult Dis()
        {
            _auditAction.Report(HttpContext, 3, Action.Show, string.Empty, string.Empty);
            TransactionalInformation tr;
            List<ProductDiscount> list = _productService.GetAllDiscountsOfProduct(1, out tr).ToList();
            return View(list);
        }
    }
}