using Microsoft.AspNetCore.Mvc;

namespace FranchiseMenu.MVC.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
