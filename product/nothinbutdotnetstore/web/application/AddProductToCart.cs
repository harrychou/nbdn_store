using System;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class AddProductToCart: ApplicationCommand {
        ResponseEngine _responseEngine;
        ShoppingCartTask service;

        public AddProductToCart()
            : this(new DefaultResponseEngine(), new StubShoppingCartTask()) {}

        public AddProductToCart(ResponseEngine _responseEngine, ShoppingCartTask service)
        {
            this._responseEngine = _responseEngine;
            this.service = service;
        }

        public void process(Request request)
        {
            var cart_item = request.map<CartItem>();

            service.add_item(cart_item);

            _responseEngine.display(service.get_current_cart_content());
        }
    }
}