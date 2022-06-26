namespace PizzaApp.Models
{
    public class ShoppingCart
    {
        public int CartId { get; set; }
        public Pizza Pizza { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
