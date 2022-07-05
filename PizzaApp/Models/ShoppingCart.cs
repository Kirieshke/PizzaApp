namespace PizzaApp.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public virtual Pizza Pizza { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
