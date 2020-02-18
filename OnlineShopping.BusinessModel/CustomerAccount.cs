using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OnlineShopping.BusinessModel
{
    public class CustomerAccount
    {
        public int Id { get; private set; }
        /* Persistance of Basket is a concern. In ideal design we don't expose Basket state and set its access level to private.
         for EF we have compromises and expose an extra property to persistence . */
        private Basket Basket;
        public string BasketString
        {
            get { return JsonConvert.SerializeObject(Basket); }
            private set
            {
                Basket = JsonConvert.DeserializeObject<Basket>(value);
            }
        }
        public void AddItemToBasket(Product pro)
        {
            /* Validation ( business logic) is required here. in fact any client may call this method and wants to change the state.
             In other words clients can or wants bypass domain services.
             Int fact access to aggregates is usuall and clients can have asscess to aggregates
             beacause they can load them from storage and then map to domain entities 
             (just aggregates becuse we model domain with repo at aggregates only).
             If they need a service that there is in domain services then
             they themself decide to call domain service. 
             */
            Basket = Basket.AddItem(pro);
        }
        // domain states should not be returned in any ways(should not be loaded in clien's memory).
        public BasketDto GetBasket()
        {
            return new BasketDto
            {
                Items = Basket.Items.Select(i => new ProductDto { }).ToList()
            };
        }
    }

    public class Basket
    {
        public List<Product> Items { get; set; }
        // We add this relation for EF. In ideal design we don't need to model this rel.todo: use fluent api.
        public CustomerAccount CustomerAccount { get; set; }
        // TODO:Consider Immutablility??
        public Basket AddItem(Product pro)
        {
            var b = new Basket
            {
                Items = this.Items
            };
            b.Items.Add(pro);
            return b;
        }
    }
}