using Microsoft.AspNetCore.Identity;
using PizzaApp.Data;
using PizzaApp.Models;

namespace PizzaApp.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public AdminRepository(AppDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public void SeedDatabase()
        {
            var _roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var cat1 = new Category { Name = "Standard" };
            var cat2 = new Category { Name = "Spcialities" };
            var cat3 = new Category { Name = "News" };

            var cats = new List<Category>()
            {
                cat1, cat2, cat3
            };

            var piz1 = new Pizza { Name = "Capricciosa", Price = 70.00M, Category = cat1, Description = "A normal pizza with a taste from the forest.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2a/Pizza_capricciosa.jpg" };
            var piz2 = new Pizza { Name = "Veggie", Price = 70.00M, Category = cat3, Description = "Veggie Pizza for vegitarians", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3f/Vegetarian_pizza.jpg" };
            var piz3 = new Pizza { Name = "Hawaii", Price = 75.00M, Category = cat1, Description = "A nice tasting pizza from Hawaii.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d1/Hawaiian_pizza_1.jpg" };
            var piz4 = new Pizza { Name = "Margarita", Price = 65.00M, Category = cat1, Description = "A basic pizza for everyone.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg"};
            var piz5 = new Pizza { Name = "Kebab Special", Price = 85.00M, Category = cat2, Description = "A special pizza with kebab for the hungry one.", ImageUrl = "http://2.bp.blogspot.com/_3cSn3Qz_4IA/THkYqKwGw1I/AAAAAAAAAPg/ybKpvRbjDWE/s1600/matsl%C3%A4kten+002.JPG" };
            var piz6 = new Pizza { Name = "Pescatore", Price = 80.00M, Category = cat1, Description = "A pizza with taste from the ocean.", ImageUrl = "https://isinginthekitchen.files.wordpress.com/2014/07/dsc_0231.jpg"};
            var piz7 = new Pizza { Name = "Barcelona", Price = 70.00M, Category = cat1, Description = "A pizza with taste from Spain, Barcelona", ImageUrl = "http://barcelona-home.com/blog/wp-content/upload/pizza/Pizzeria%20Los%20Amigos/pizza-jamon-dulce-y-champinone.jpg" };
            var piz8 = new Pizza { Name = "Flying Jacob", Price = 89.00M, Category = cat2, Description = "Flying pizza from the sky, with taste of banana.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/64/Pizza_Hawaii_Special_p%C3%A5_Pizzeria_Papillon_i_Sala_1343.jpg" };
            var piz9 = new Pizza { Name = "Kentucky", Price = 69.00M, Category = cat3, Description = "A pizza from America with the taste of Kuntucky Chicken.", ImageUrl = "http://assets.kraftfoods.com/recipe_images/opendeploy/54150_640x428.jpg"};
            var piz10 = new Pizza { Name = "La Carne", Price = 75.00M, Category = cat1, Description = "Italian pizza with lot's of delicious meat.", ImageUrl = "https://www.davannis.com/wp-content/uploads/2015/03/five-meat.jpg"};

            var pizs = new List<Pizza>()
            {
                piz1, piz2, piz3, piz4, piz5, piz6, piz7, piz8, piz9, piz10
            };

            var user1 = new IdentityUser { UserName = "user1@gmail.com", Email = "user1@gmail.com" };
            var user2 = new IdentityUser { UserName = "user2@gmail.com", Email = "user2@gmail.com" };
            var user3 = new IdentityUser { UserName = "user3@gmail.com", Email = "user3@gmail.com" };
            var user4 = new IdentityUser { UserName = "user4@gmail.com", Email = "user4@gmail.com" };
            var user5 = new IdentityUser { UserName = "user5@gmail.com", Email = "user5@gmail.com" };

            string userPassword = "Password123";

            var users = new List<IdentityUser>()
            {
                user1, user2, user3, user4, user5
            };

            foreach (var user in users)
            {
                _userManager.CreateAsync(user, userPassword).Wait();
            }



            var ing1 = new Ingredient { Name = "Cheese" };
            var ing2 = new Ingredient { Name = "Flour" };
            var ing3 = new Ingredient { Name = "Tomatoe sauce" };
            var ing4 = new Ingredient { Name = "Lettuce" };
            var ing5 = new Ingredient { Name = "Mushrooms" };
            var ing6 = new Ingredient { Name = "Kebab" };
            var ing7 = new Ingredient { Name = "Shrimp" };
            var ing8 = new Ingredient { Name = "Pineapple" };
            var ing9 = new Ingredient { Name = "Ham" };
            var ing10 = new Ingredient { Name = "Broccoli" };
            var ing11 = new Ingredient { Name = "Onions" };
            var ing12 = new Ingredient { Name = "Olives" };
            var ing13 = new Ingredient { Name = "Bananas" };
            var ing14 = new Ingredient { Name = "Chicken" };
            var ing15 = new Ingredient { Name = "Tomatoes" };
            var ing16 = new Ingredient { Name = "Minced Meat" };

            var ings = new List<Ingredient>()
            {
                ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9, ing10, ing11, ing12, ing13, ing14, ing15, ing16
            };

            var pizIngs = new List<PizzaIngredients>()
            {
                new PizzaIngredients { Ingredient = ing1, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing5, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing9, Pizza = piz1 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing4, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing10, Pizza = piz2 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing8, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing9, Pizza = piz3 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz4 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz4 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz4 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing6, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing4, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing11, Pizza = piz5 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing4, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing7, Pizza = piz6 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing5, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing11, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing12, Pizza = piz7 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing5, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing8, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing13, Pizza = piz8 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing14, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing15, Pizza = piz9 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing9, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing16, Pizza = piz10 },

            };

            var ord1 = new Order
            {
                FirstName = "Pelle",
                LastName = "Andersson",
                AddressLine1 = "MainStreet 12",
                City = "Gothenburg",
                Country = "Sweden",
                Email = "pelle22@gmail.com",
                OrderPlaced = DateTime.Now.AddDays(-2),
                PhoneNumber = "0705123456",
                User = user1,
                ZipCode = "43210",
                OrderTotal = 370.00M,
            };

            var ord2 = new Order { };
            var ord3 = new Order { };

            var orderLines = new List<OrderDetail>()
            {
                new OrderDetail { Order=ord1, Pizza=piz1, Amount=2, Price=piz1.Price},
                new OrderDetail { Order=ord1, Pizza=piz3, Amount=1, Price=piz3.Price},
                new OrderDetail { Order=ord1, Pizza=piz5, Amount=3, Price=piz5.Price},
            };

            var orders = new List<Order>()
            {
                ord1
            };

            _context.Categories.AddRange(cats);
            _context.Pizzas.AddRange(pizs);
            _context.Orders.AddRange(orders);
            _context.OrderDetails.AddRange(orderLines);
            _context.Ingredient.AddRange(ings);
            _context.PizzaIngredients.AddRange(pizIngs);

            _context.SaveChanges();
        }

        public void ClearDatabase()
        {
            var pizzaIngredients = _context.PizzaIngredients.ToList();
            _context.PizzaIngredients.RemoveRange(pizzaIngredients);

            var ingredients = _context.Ingredient.ToList();
            _context.Ingredient.RemoveRange(ingredients);

            var shoppingCartItems = _context.ShoppingCarts.ToList();
            _context.ShoppingCarts.RemoveRange(shoppingCartItems);

            var users = _context.Users.ToList();
            var userRoles = _context.UserRoles.ToList();

            foreach (var user in users)
            {
                if (!userRoles.Any(r => r.UserId == user.Id))
                {
                    _context.Users.Remove(user);
                }
            }

            var orderDetails = _context.OrderDetails.ToList();
            _context.OrderDetails.RemoveRange(orderDetails);

            var orders = _context.Orders.ToList();
            _context.Orders.RemoveRange(orders);

            var pizzas = _context.Pizzas.ToList();
            _context.Pizzas.RemoveRange(pizzas);

            var categories = _context.Categories.ToList();
            _context.Categories.RemoveRange(categories);

            _context.SaveChanges();
        }

    }
}

