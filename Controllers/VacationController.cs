using Microsoft.AspNetCore.Mvc;

namespace Top5.Controllers
{
    public class VacationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Number1()
        {
            return View();
        }

        [HttpGet("rank/{id:int:range(1,5)}")]
        public IActionResult Number(int id)
        {
            string[] items =
            {
                "Dolphin Cove",
                "Dunn's River Falls",
                "Blue Hole",
                "Blue Lagoon",
                "Blue and Johncrow Mountains National Park",
                "lollipop",
                "babygirl",
                "sugar dumpling"
            };

            ViewData["Items"] = $"{items[id-1]}";
            return View();
        }

        [HttpGet("about-my-list")]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult NotOnList()
        {
            return View();
        }
    }
}
