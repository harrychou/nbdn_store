using System;

namespace nothinbutdotnetstore.domain
{
    public class CartItem
    {
        public virtual void increment_quantity_by(int quantity)
        {
            throw new NotImplementedException();
        }

        public virtual bool is_item_for(Product product)
        {
            throw new NotImplementedException();
        }

        public virtual void change_quantity_to(int new_quantity)
        {
            throw new NotImplementedException();
        }

        public virtual decimal calculate_total_cost()
        {
            throw new NotImplementedException();
        }
    }
}