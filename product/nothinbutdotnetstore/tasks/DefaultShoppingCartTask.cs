using System;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public class DefaultShoppingCartTask : ShoppingCartTask {
        private readonly ShoppingCart shopping_cart;
        private readonly Catalog catalog;

        public DefaultShoppingCartTask(ShoppingCart shopping_cart, Catalog catalog)
        {
            this.shopping_cart = shopping_cart;
            this.catalog = catalog;
        }

        public void add_product_to_cart(LineItem line_item)
        {
            shopping_cart.add_item(catalog.get_product(line_item.product_id), line_item.quantity);
        }
    }
}