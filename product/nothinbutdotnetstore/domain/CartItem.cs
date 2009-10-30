namespace nothinbutdotnetstore.domain
{
    public class CartItem
    {
        protected CartItem() {}

        public CartItem(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

        public virtual void increment_quantity_by(int quantity)
        {
            this.quantity += quantity;
        }

        public virtual bool is_item_for(Product product)
        {
            return this.product.Equals(product);
        }

        public virtual void change_quantity_to(int new_quantity)
        {
            quantity = new_quantity;
        }

        public virtual decimal calculate_total_cost()
        {
            return quantity*product.price;
        }

        public virtual int quantity { get; protected set;}
        public virtual Product product { get; protected set; }
    }
}