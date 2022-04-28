namespace P03.Before
{
    public abstract class Order
    {
        protected readonly Cart cart;

        public Order(Cart cart)
        {
            this.cart = cart;
        }

        public virtual void Checkout()
        {
            // log the order in the database
        }
    }
}
