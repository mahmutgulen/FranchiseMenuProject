using FranchiseMenu.CORE.Entities;
using FranchiseMenu.CORE.Utilities.Result;
using FranchiseMenu.ENTITY.Dtos.FoodDtos;

namespace FranchiseMenu.BLL.Abstract
{
    public interface IFoodService
    {
        IDataResult<bool> FoodAdd(FoodAddDto dto);
        IDataResult<bool> FoodUpdate(FoodUpdateDto dto);
        IDataResult<bool> FoodChangeStatus(int foodId);

        IDataResult<List<FoodGetAllDto>> FoodGetAll();
        IDataResult<bool> DeleteFood(int id);
        IDataResult<FoodGetByIdDto> FoodGetById(int foodId, string token);
        IDataResult<List<FoodGetByCategoryIdDto>> FoodGetByCategoryId(int categoryId, string token);
        //Paging ekle !!!

    }
}
