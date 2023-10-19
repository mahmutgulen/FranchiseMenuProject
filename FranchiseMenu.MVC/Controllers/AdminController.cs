using FranchiseMenu.BLL.Abstract;
using FranchiseMenu.ENTITY.Dtos.AuthDtos;
using FranchiseMenu.ENTITY.Dtos.CategoryDtos;
using FranchiseMenu.ENTITY.Dtos.FoodDtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FranchiseMenu.DAL.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace FranchiseMenu.MVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IFoodService _foodService;
        private readonly IAuthService _authService;
        private readonly IAdminDal _adminDal;

        public AdminController(ICategoryService categoryService, IFoodService foodService, IAuthService authService, IAdminDal adminDal)
        {
            _categoryService = categoryService;
            _foodService = foodService;
            _authService = authService;
            _adminDal = adminDal;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Categories", "Admin");
        }

        [HttpGet]
        public IActionResult Categories()
        {
            var result = _categoryService.CategoryGetAll().Data;
            return View(result);
        }

        [HttpPost]
        public IActionResult Categories(CategoryAddDto dto)
        {
            if (String.IsNullOrEmpty(dto.CategoryName))
            {
                return RedirectToAction("Categories", "Admin");
            }
            var result = _categoryService.CategoryAdd(dto);
            return RedirectToAction("Categories", "Admin");
        }

        [HttpGet]
        public IActionResult Foods()
        {
            var result = _foodService.FoodGetAll().Data;
            return View(result);
        }

        [HttpPost]
        public IActionResult Foods(FoodAddDto dto)
        {

            var result = _foodService.FoodAdd(dto);
            return RedirectToAction("Foods", "Admin");
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginDto dto)
        {
            var result = _authService.Login(dto);
            if (result.Data)
            {
                var admin = _adminDal.Get(x => x.AdminEmail == dto.AdminEmail);
                var adminId = admin.Id;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,dto.AdminEmail),
                    new Claim(ClaimTypes.NameIdentifier,adminId.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Login", "Admin");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Admin");
        }

        [HttpGet]
        public IActionResult ChangeStatusCategory(int id)
        {
            var result = _categoryService.CategoryChangeStatus(id);
            return RedirectToAction("Categories", "Admin");
        }

        [HttpGet]
        public IActionResult ChangeStatusFood(int id)
        {
            var result = _foodService.FoodChangeStatus(id);
            return RedirectToAction("Foods", "Admin");
        }

        [HttpGet]
        public IActionResult DeleteFood(int id)
        {
            var result = _foodService.DeleteFood(id);
            return RedirectToAction("Foods", "Admin");
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            return RedirectToAction("Categories", "Admin");
        }
    }
}
