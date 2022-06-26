namespace PizzaApp.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }
    }
}
