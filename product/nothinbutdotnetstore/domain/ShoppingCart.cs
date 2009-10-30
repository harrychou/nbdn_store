using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.domain
{
    public class ShoppingCart
    {
        CartItemFactory item_factory;
        public virtual IList<CartItem> items { get; set; }

        public ShoppingCart() {}

        public ShoppingCart(CartItemFactory item_factory, IList<CartItem> items)
        {
            this.item_factory = item_factory;
            this.items = items;
        }

        public virtual void add(Product product_to_add, int quantity_of_product)
        {
            if (contains_item_for(product_to_add))
            {
                get_item_for(product_to_add).increment_quantity_by(quantity_of_product);
                return;
            }
            items.Add(item_factory.create_item_for(product_to_add, quantity_of_product));
        }

        CartItem get_item_for(Product product_to_add)
        {
            return items.First(item => item.is_item_for(product_to_add));
        }

        bool contains_item_for(Product product_to_add)
        {
            return items.Any(item => item.is_item_for(product_to_add));
        }

        public virtual void change_quantity(Product product, int new_quantity)
        {
            get_item_for(product).change_quantity_to(new_quantity);
        }

        public virtual void remove(Product product)
        {
            items.Remove(get_item_for(product));
        }

        public virtual void empty()
        {
            items.Clear();
        }

        public virtual decimal calculate_total_cost()
        {
            return items.Sum(item => item.calculate_total_cost());
        }
    }
}