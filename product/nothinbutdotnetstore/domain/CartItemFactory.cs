namespace nothinbutdotnetstore.domain
{
    public class CartItemFactory
    {
        public virtual CartItem create_item_for(Product product, int initial_quanity)
        {
            return new CartItem(product, initial_quanity);
        }
    }
}