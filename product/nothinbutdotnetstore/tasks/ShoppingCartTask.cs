using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface ShoppingCartTask {
        void add_product_to_cart(LineItem line_item);
    }
}