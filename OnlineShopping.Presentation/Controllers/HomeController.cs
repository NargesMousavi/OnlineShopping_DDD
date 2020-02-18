using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopping.Presentation.Models;
using OnlineShopping.BusinessModel;
using System.Linq;

namespace OnlineShopping.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICustomerAccountRepository customerAccountRepo;
        private IProductRepository prodRepo;
        private readonly ProductService productService;

        public HomeController(ILogger<HomeController> logger, ICustomerAccountRepository accountRepo, IProductRepository proRepo)
        {
            customerAccountRepo = accountRepo;
            prodRepo = proRepo;
            _logger = logger;
            // productService = new ProductService(accountRepo, proRepo);
        }
        public IActionResult GetProductList(int catId)
        {
            // We can Refactor to productService.GetProductListByCat(catId) to centralized services if we require this service one more.
            // Note that creation dtos based on client requirments is responsibility of application services not domain itself.
            var ps = prodRepo.GetAllByCat(catId);
           var r= ps.Select(p => new ProductDto
            {

            }
            ).ToList();
            return View();
        }
        public IActionResult AddItemToProduct(int accountId, int productId)
        {
            productService.AddItemToProduct(accountId, productId);
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
