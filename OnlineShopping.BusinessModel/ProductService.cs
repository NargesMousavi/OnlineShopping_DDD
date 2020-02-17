using System;

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
            var account = customerAccountRepo.Get(accountId);
            var pro = prodRepo.Get(accountId);
            account.AddItemToBasket(pro);
            customerAccountRepo.Update(account);//means write and state changes.
        }
    }
}
