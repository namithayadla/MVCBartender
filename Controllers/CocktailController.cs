using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MVCBartenderApp.Models;
using System.Linq;
namespace MVCBartenderApp.Controllers {
    public class CocktailController: Controller {
        private static List<Cocktail> _cocktails = new List<Cocktail> {
            new Cocktail { ID = 1, Name = "Mojito", Ingredients = "Rum, Mint, Lime, Sugar, Soda", Price = 9},
            new Cocktail { ID = 2, Name = "Margarita", Ingredients = "Tequila, Triple Sec, Lime Juice", Price = 10},
            new Cocktail { ID = 3, Name = "Aperol Spritz", Ingredients = "Aperol, Prosecco, Soda", Price = 12},
            new Cocktail { ID = 4, Name = "Martini", Ingredients = "Vodka, Vermouth, Olive", Price = 8},
            new Cocktail { ID = 5, Name = "Moscow Mule", Ingredients = "Vodka, Ginger Beer, Mint", Price = 10}
        };
        private static List<Order> _orders = new List<Order>();

        public IActionResult Index() {
            return View();
        }
        public IActionResult ShowMenu() {
            return View("Menu", _cocktails);
        }
        [HttpPost]
        public IActionResult PlaceOrder(int cocktailId, string customerName, string customerEmail) {
            var cocktail = _cocktails.Find(c => c.ID == cocktailId);
            if (cocktail == null) {
                return NotFound();
            }
            var order = new Order {
                ID = _orders.Count + 1,
                CocktailID = cocktailId,
                CocktailName = cocktail.Name,
                CustomerName = customerName,
                CustomerEmail = customerEmail,
                Status = "Ordered"
            };
            _orders.Add(order);
            return RedirectToAction("Confirmation", new { orderId = order.ID });
        }
        public IActionResult Confirmation(int orderId) {
            var order = _orders.Find(o => o.ID == orderId);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        public IActionResult ViewOrderQueue() {
            var viewModel = new OrderQueue {
                Orders = _orders,
                Cocktails = _cocktails
            };
            return View("OrderQueue", viewModel);
        }
    }
}