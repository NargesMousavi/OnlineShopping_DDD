using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopping.Presentation.Models;
using OnlineShopping.BusinessModel;
using System.Linq;

namespace OnlineShopping.Presentation.Controllers
{
    public class HomeController : ApiController
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
        // Here we define business(product) services. Business APIs for clients.(Senarios)
        public List<ProductDto> GetProductList(int catId)
        {
            // We can Refactor to productService.GetProductListByCat(catId) to centralized services if we require this service one more.
            // Note that creation dtos based on client requirments is responsibility of application services not domain itself.
            var ps = prodRepo.GetAllByCat(catId);
            var r = ps.Select(p => new ProductDto
            {

            }
             ).ToList();
            return r;
        }
        [Authorization] //Is needed for accountId.
        public bool AddItemToBasket( int productId)
        {
            //get accountId from the profile of current (signed in) user.
            productService.AddItemToBasket(accountId, productId);
            return true;
        }
        [Authorization] //Is needed for accountId.
        public ShippingOptionsDto GetShippingOptionsForBasket()
        {
            //get accountId from the profile of current (signed in) user.
            return productService.GetShippingOptionsForBasket(accountId); 
        }
        [Authorization] //Is needed for accountId.
        public bool FinalizeBasket(string shippingId, string paymentToken)
        {
            //get accountId from the profile of current (signed in) user.
            productService.FinalizeBasket(accountId);
            return true;
        }
    }
}
