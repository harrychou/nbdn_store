using System;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubShoppingCartTask : ShoppingCartTask {
        public void add_product_to_cart(LineItem line_item)
        {
            throw new NotImplementedException();
        }
    }
}