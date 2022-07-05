using Microsoft.EntityFrameworkCore;
using PizzaApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class ShoppingCartAction
    {
        private readonly AppDbContext _appDbContext;

        private ShoppingCartAction(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCart> ShoppingCartItems { get; set; }


        public static ShoppingCartAction GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCartAction(context) { ShoppingCartId = cartId };
        }

        public async Task AddToCartAsync(Pizza pizza, int amount)
        {
            var shoppingCartItem =
                    await _appDbContext.ShoppingCarts.SingleOrDefaultAsync(
                        s => s.Pizza.Id == pizza.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCart
                {
                    ShoppingCartId = ShoppingCartId,
                    Pizza = pizza,
                    Amount = 1
                };

                _appDbContext.ShoppingCarts.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveFromCartAsync(Pizza pizza)
        {
            var shoppingCartItem =
                    await _appDbContext.ShoppingCarts.SingleOrDefaultAsync(
                        s => s.Pizza.Id == pizza.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCarts.Remove(shoppingCartItem);
                }
            }

            await _appDbContext.SaveChangesAsync();

            return localAmount;
        }

        public async Task<List<ShoppingCart>> GetShoppingCartItemsAsync()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems = await
                       _appDbContext.ShoppingCarts.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Pizza)
                           .ToListAsync());
        }

        public async Task ClearCartAsync()
        {
            var cartItems = _appDbContext.
                ShoppingCarts
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCarts.RemoveRange(cartItems);

            await _appDbContext.SaveChangesAsync();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCarts.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pizza.Price * c.Amount).Sum();
            return total;
        }
    }
}
