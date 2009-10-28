using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class AddToCart :ApplicationCommand {
        private readonly ShoppingCartTask shoppingCartTask;

        public AddToCart(ShoppingCartTask shoppingCartTask)
        {
            this.shoppingCartTask = shoppingCartTask;
        }

        public void process(Request request)
        {
            shoppingCartTask.add_product_to_cart(request.map<LineItem>());
        }
    }
}