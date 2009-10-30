using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public class DefaultShoppingCartTask : ShoppingCartTask
    {
        CartCorral cart_corral;
        Catalog catalog;

        public DefaultShoppingCartTask(CartCorral cart_corral, Catalog catalog)
        {
            this.cart_corral = cart_corral;
            this.catalog = catalog;
        }

        public void add_product_to_cart(LineItem line_item)
        {
            cart_corral.get_cart().add(catalog.get_product(line_item.product_id), line_item.quantity);
        }
    }
}