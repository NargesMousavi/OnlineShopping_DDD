using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopping.Presentation.Models;
using OnlineShopping.BusinessModel;

namespace OnlineShopping.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProductService productService;

        public HomeController(ILogger<HomeController> logger, ICustomerAccountRepository repo)
        {
            _logger = logger;
            productService=new  ProductService(repo);
        }
        public IActionResult AddItemToProduct(int AccountId,int ProductId)
        {
            productService.AddItemToProduct(AccountId,ProductId);
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
