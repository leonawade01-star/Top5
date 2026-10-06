using Microsoft.AspNetCore.Mvc;
using Top5.Models;

namespace Top5.Controllers
{
    public class MenuController : Controller
    {
        private static List<Dish> specials_for_the_day = new List<Dish>
{
    new Dish { Id = 1, Name = "Chicken Soup", Price = 700, IsSpicy = false },
    new Dish { Id = 2, Name = "Curry Goat", Price = 1500, IsSpicy = true },
    new Dish { Id = 3, Name = "Pepper Shrimp", Price = 2000, IsSpicy = true },
};
        public IActionResult Show(string day)
        {
            ViewData["Title"] = "Menu";
            ViewBag.Day = day;

            if (day.ToLower() == "sunday")
            {
                return View(new List<Dish>());
            }
            return View(specials_for_the_day); 
        }

        [HttpGet("menu/order/{id:int}")]
        public IActionResult Order(int id)
        {
            foreach (Dish each_dish in specials_for_the_day)
            {
                if (each_dish.Id == id)
                {
                    TempData["Message"] = $"Added {each_dish.Name} to your order";
                    return RedirectToAction("Show");
                }
            }
            return NotFound();
        }
        [HttpGet("menu/new")]
        public IActionResult New()
        {
            return View(new Dish()); 
        }
        [HttpPost("menu/add")]
        public IActionResult Add(Dish new_dish) 
        {
            if (!ModelState.IsValid)
            {
                return View("New", new_dish);
            }
            new_dish.Id = specials_for_the_day.Count + 1; specials_for_the_day.Add(new_dish);
            TempData["Message"] = $"{new_dish.Name} is on the menu";
            return RedirectToAction("Show");
        }
    }
}


