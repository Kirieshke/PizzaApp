using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);

    }
}
