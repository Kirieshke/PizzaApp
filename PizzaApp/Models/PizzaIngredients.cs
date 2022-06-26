using System.ComponentModel;

namespace PizzaApp.Models
{
    public class PizzaIngredients
    {
        public int Id { get; set; }
        [DisplayName("Select Pizza")]
        public int PizzaId { get; set; }

        [DisplayName("Select Ingredient")]
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
