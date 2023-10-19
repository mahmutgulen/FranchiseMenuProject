using FranchiseMenu.BLL.Abstract;
using FranchiseMenu.ENTITY.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace FranchiseMenu.UI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _categoryService.CategoryGetAll().Data;
            return View(result);
        }

        public IActionResult Add(CategoryAddDto dto)
        {
            var result = _categoryService.CategoryAdd(dto);

            ViewBag.Message = result.MessageCode;
            return View();
        }
    }
}
