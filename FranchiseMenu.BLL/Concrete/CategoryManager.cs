using FranchiseMenu.BLL.Abstract;
using FranchiseMenu.BLL.Contants;
using FranchiseMenu.CORE.Utilities.Result;
using FranchiseMenu.DAL.Abstract;
using FranchiseMenu.ENTITY.Concrete;
using FranchiseMenu.ENTITY.Dtos.CategoryDtos;

namespace FranchiseMenu.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<bool> CategoryAdd(CategoryAddDto dto)
        {
            try
            {
                var category = _categoryDal.Get(x => x.CategoryName == dto.CategoryName);
                if (category != null)
                {
                    if (category.CategoryStatus == false)
                    {
                        return new ErrorDataResult<bool>(false, "category available but not active", Messages.category_available_but_not_active);
                    }
                    return new ErrorDataResult<bool>(false, "category already exists", Messages.category_already_exists);
                }

                var categoryAdd = new Category
                {
                    CategoryName = dto.CategoryName,
                    CategoryStatus = true,
                };
                _categoryDal.Add(categoryAdd);
                return new SuccessDataResult<bool>(true, "category added", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unknownError);
            }
        }

        public IDataResult<bool> CategoryChangeStatus(int categoryId)
        {
            try
            {

                var category = _categoryDal.Get(x => x.Id == categoryId);
                if (category == null)
                {
                    return new ErrorDataResult<bool>(false, "category not found", Messages.category_not_found);
                }
                if (category.CategoryStatus == true)
                {
                    category.CategoryStatus = false;
                    _categoryDal.Update(category);
                    return new SuccessDataResult<bool>(true, "category status changed", Messages.category_status_changed);
                }
                category.CategoryStatus = true;
                _categoryDal.Update(category);
                return new SuccessDataResult<bool>(true, "category status changed", Messages.category_status_changed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unknownError);
            }
        }

        public IDataResult<List<CategoryGetAllDto>> CategoryGetAll()
        {
            try
            {

                var categories = _categoryDal.GetAll();
                if (categories == null)
                {
                    return new ErrorDataResult<List<CategoryGetAllDto>>(new List<CategoryGetAllDto>(), "category not found", Messages.category_not_found);
                }

                var list = new List<CategoryGetAllDto>();
                foreach (var item in categories)
                {
                    list.Add(new CategoryGetAllDto
                    {
                        CategoryName = item.CategoryName,
                        CategoryStatus = item.CategoryStatus,
                        Id = item.Id
                    });
                }
                return new SuccessDataResult<List<CategoryGetAllDto>>(list, "ok", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CategoryGetAllDto>>(new List<CategoryGetAllDto>(), e.Message, Messages.unknownError);
            }
        }

        public IDataResult<CategoryGetByIdDto> CategoryGetById(int categoryId)
        {
            try
            {


                var category = _categoryDal.Get(x => x.Id == categoryId);
                if (category == null)
                {
                    return new ErrorDataResult<CategoryGetByIdDto>(new CategoryGetByIdDto(), "category not found", Messages.category_not_found);
                }

                var dto = new CategoryGetByIdDto
                {
                    CategoryName = category.CategoryName,
                    CategoryStatus = category.CategoryStatus,
                    Id = category.Id
                };
                return new SuccessDataResult<CategoryGetByIdDto>(dto, "ok", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CategoryGetByIdDto>(new CategoryGetByIdDto(), e.Message, Messages.unknownError);
            }
        }

        public IDataResult<bool> CategoryUpdate(CategoryUpdateDto dto)
        {
            try
            {
                //var tokenCheck = _sessionService.TokenCheck(dto.Token);
                //if (!tokenCheck.Success)
                //{
                //    return new ErrorDataResult<bool>(false, tokenCheck.Message, tokenCheck.MessageCode);
                //}

                var category = _categoryDal.Get(x => x.Id == dto.CategoryId);

                if (category == null)
                {
                    return new ErrorDataResult<bool>(false, "category not found", Messages.category_not_found);
                }

                var nameCheck = _categoryDal.Get(x => x.Id != category.Id && x.CategoryName == dto.CategoryName);

                if (nameCheck != null)
                {
                    return new ErrorDataResult<bool>(false, "category of the same name exists", Messages.category_of_the_same_name_exists);
                }

                category.CategoryStatus = dto.CategoryStatus;
                category.CategoryName = dto.CategoryName;
                _categoryDal.Update(category);
                return new SuccessDataResult<bool>(true, "category updated", Messages.success);

            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unknownError);
            }
        }


        public IDataResult<bool> DeleteCategory(int id)
        {
            try
            {
                var category = _categoryDal.Get(x => x.Id == id);

                _categoryDal.Delete(category);
                return new SuccessDataResult<bool>(true, "category_deleted", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unknownError);
            }
        }
    }
}
