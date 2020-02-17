namespace OnlineShopping.BusinessModel
{
    public interface ICustomerAccountRepository
    {
        CustomerAccount Get(int id);
        void Update(CustomerAccount account);
    }
}