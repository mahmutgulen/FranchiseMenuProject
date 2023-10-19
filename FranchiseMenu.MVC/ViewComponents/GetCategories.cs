using FranchiseMenu.BLL.Abstract;
using FranchiseMenu.ENTITY.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace FranchiseMenu.MVC.ViewComponents
{
    public class GetCategories : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public GetCategories(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _categoryService.CategoryGetAll().Data;
            var list = new List<CategoryGetAllDto>();
            foreach (var item in result)
            {
                if (item.CategoryStatus == true)
                {
                    list.Add(new CategoryGetAllDto
                    {
                        CategoryName = item.CategoryName,
                        CategoryStatus = item.CategoryStatus,
                        Id = item.Id
                    });
                }
            }
            return View(list);
        }
    }
}
