namespace PizzaApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Pizza> Pizzas{ get; set; }
    }
}
