using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OnlineShopping.BusinessModel
{
    public class CustomerAccount
    {
        public int Id { get; private set; }
        public Basket Basket { get; private set; }
        public void AddItemToBasket(Product pro)
        {
            /* Validation (business logic) is required here. in fact any client may call this method and wants to change the state.
             In other words clients can or wants bypass domain services.
             Int fact access to aggregates is usuall and clients can have asscess to aggregates
             beacause they can load them from storage and then map to domain entities 
             (just aggregates becuse we model domain with repo at aggregates only).
             If they need a service that there is in domain services then
             they themself decide to call domain service. 
             */
            Basket.AddItem(pro);
        }
    }
    public class Basket
    {
        public int CustomerAccountId { get; private set; }//it's key of basket.
        private IEnumerable<Product> Items;//Do encapsulation. set to private.
        public IEnumerable<Product> GetItems()
        {
            return Items; //Do encapsulation
        }
        public void AddItem(Product pro)
        {
            Items.ToList().Add(pro);
        }
    }
}