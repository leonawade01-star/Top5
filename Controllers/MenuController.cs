using Microsoft.AspNetCore.Mvc;

namespace Top5.Controllers
{
    public class MenuController : Controller
    {

        public IActionResult Show(string day)
        {
            day = day?.ToLower();

            ViewBag.Day = day;
            ViewBag.Price = 1500;

            if (day == "saturday" || day == "sunday")
            {
                ViewBag.Specials = new List<string>
                {
                    "Jerk Chicken",
                    "Rice and Peas",
                    "Festival"
                };

                ViewBag.Price = 1800;
            }
            else
            {
                ViewBag.Specials = new List<string>
                {
                    "Stew Peas",
                    "Escovitch Fish",
                    "Mannish Water"
                };

                ViewBag.Price = 1500;
            }
            return View();
        }
    }
}
