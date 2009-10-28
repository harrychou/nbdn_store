using System.Collections.Generic;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface ShoppingCartTask {
        void add_item(CartItem item);
        IEnumerable<CartItem> get_current_cart_content();
    }
}