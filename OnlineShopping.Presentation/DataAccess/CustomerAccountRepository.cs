using OnlineShopping.BusinessModel;
using OnlineShopping.Presentation.DataAccess;

public class CustomerAccountRepository : ICustomerAccountRepository
{
    public CustomerAccount Get(int id)
    {
        using (var dbCtx = new OnlineShoppingDbContext())
        {
            return dbCtx.CustomerAccounts.Find(id);
        }
    }

    public void Update(CustomerAccount account)
    {
        using (var dbCtx = new OnlineShoppingDbContext())
        {
             dbCtx.CustomerAccounts.Update(account);
             dbCtx.SaveChanges();
        }
    }
}