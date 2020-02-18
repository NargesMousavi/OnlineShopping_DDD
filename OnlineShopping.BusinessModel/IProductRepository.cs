using System.Collections.Generic;

namespace OnlineShopping.BusinessModel
{
    public interface IProductRepository
    {
        Product Get(int id);
        List<Product> GetAllByCat(int catId);
    }
}