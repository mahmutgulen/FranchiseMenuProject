using FranchiseMenu.CORE.Utilities.Result;
using FranchiseMenu.ENTITY.Dtos.CategoryDtos;

namespace FranchiseMenu.BLL.Abstract
{
    public interface ICategoryService
    {
        IDataResult<bool> CategoryAdd(CategoryAddDto dto);
        IDataResult<bool> CategoryUpdate(CategoryUpdateDto dto);
        IDataResult<bool> CategoryChangeStatus(int categoryId);
        IDataResult<List<CategoryGetAllDto>> CategoryGetAll();
        IDataResult<bool> DeleteCategory(int id);
        IDataResult<CategoryGetByIdDto> CategoryGetById(int categoryId);
        //Paging ekle !!!
    }
}
