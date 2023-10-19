using Microsoft.AspNetCore.Mvc;

namespace FranchiseMenu.UI.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
