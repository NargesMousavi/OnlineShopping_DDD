using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopping.BusinessModel
{
    public class ProductService
    {
        private ICustomerAccountRepository customerAccountRepo;
        private IProductRepository prodRepo;
        public ProductService(ICustomerAccountRepository accountRepo, IProductRepository proRepo)
        {
            customerAccountRepo = accountRepo;
            prodRepo = proRepo;
        }

        public void AddItemToProduct(int accountId, int productId)
        {
            //In this step We can see that ACs is required to acomplish steps in this service.(YAGNI & iterrative)
            //todo: write tests.
            // Note that these steps can be done by any client.
            var account = customerAccountRepo.Get(accountId);
            var pro = prodRepo.Get(accountId);
            account.AddItemToBasket(pro);
            customerAccountRepo.Update(account);//means write and state changes.
        }

        public List<ProductDto> GetProductListByCat(int catId)
        {
             //todo: Refactore: Note that creation dtos based on client requirments is responsibility of application services not domain itself.
            var ps=prodRepo.GetAllByCat(catId);
            return ps.Select(p=> new ProductDto
            {

            }
            ).ToList();
        }
    }
}
