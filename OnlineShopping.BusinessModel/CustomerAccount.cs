using System.Collections.Generic;
using System.Linq;

namespace OnlineShopping.BusinessModel
{
    public class CustomerAccount
    {
        public int Id{get; private set;}
        private Basket Basket;
        internal void AddItemToBasket(Product pro)
        {
           /* validation ( business logic) is required here. in fact any client may call this method and wants to change the state.
            In other words clients can or wants bypass domain services.
            Int fact access to aggregates is usuall and clients can have asscess to aggregates
            beacause they can load them from storage and then map to domain entities 
            (just aggregates becuse we model domain with repo at aggregates only).
            If they need a service that there is in domain services then
            they themself decide to call domain service. 
            */
            Basket.AddItem(pro); 
        }
        // domain states should not be returned in any ways(should not be loaded in clien's memory).
        public BasketDto GetBasket()
        {
            return new BasketDto
            {
                Items = Basket.Items.Select(i => new ProductDo { }).ToList()
            };
        }
    }

    internal class Basket
    {
        public List<Product> Items { get; set; }
        internal void AddItem(Product pro)
        {
            Items.Add(pro);
        }
    }
}