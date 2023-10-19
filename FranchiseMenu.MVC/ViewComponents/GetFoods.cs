using FranchiseMenu.BLL.Abstract;
using FranchiseMenu.ENTITY.Dtos.CategoryDtos;
using FranchiseMenu.ENTITY.Dtos.FoodDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace FranchiseMenu.MVC.ViewComponents
{
    public class GetFoods : ViewComponent
    {
        private readonly IFoodService _foodService;

        public GetFoods(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _foodService.FoodGetAll().Data;
            var list = new List<FoodGetAllDto>();
            foreach (var item in result)
            {
                if (item.FoodStatus == true)
                {
                    list.Add(new FoodGetAllDto()
                    {
                        CategoryId = item.CategoryId,
                        FoodStatus = item.FoodStatus,
                        FoodDescription = item.FoodDescription,
                        FoodImage = item.FoodImage,
                        FoodName = item.FoodName,
                        FoodPrice = item.FoodPrice,
                        Id = item.Id,
                        CategoryName = item.CategoryName,
                    });
                }
            }
            return View(list);
        }
    }
}
