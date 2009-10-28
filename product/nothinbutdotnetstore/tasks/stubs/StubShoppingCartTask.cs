using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubShoppingCartTask : ShoppingCartTask
    {
        public void add_item(CartItem item)
        {
            return;
        }

        public IEnumerable<CartItem> get_current_cart_content()
        {
            return Enumerable.Range(2, 5).Select(x => new CartItem{product_name = "product " + x.ToString(), quantity = x});
        }
    }
}