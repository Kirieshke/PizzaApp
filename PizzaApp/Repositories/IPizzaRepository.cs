using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> Pizzas { get; }
        IEnumerable<Pizza> PizzasOfTheWeek { get; }

        Pizza GetById(int? id);
        Task<Pizza> GetByIdAsync(int? id);

        Pizza GetByIdIncluded(int? id);
        Task<Pizza> GetByIdIncludedAsync(int? id);

        bool Exists(int id);

        IEnumerable<Pizza> GetAll();
        Task<IEnumerable<Pizza>> GetAllAsync();

        IEnumerable<Pizza> GetAllIncluded();
        Task<IEnumerable<Pizza>> GetAllIncludedAsync();

        void Add(Pizza pizza);
        void Update(Pizza pizza);
        void Remove(Pizza pizza);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
