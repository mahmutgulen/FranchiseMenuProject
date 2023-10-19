using FranchiseMenu.BLL.Abstract;
using FranchiseMenu.BLL.Contants;
using FranchiseMenu.CORE.Entities;
using FranchiseMenu.CORE.Utilities.Result;
using FranchiseMenu.DAL.Abstract;
using FranchiseMenu.ENTITY.Concrete;
using FranchiseMenu.ENTITY.Dtos.FoodDtos;
using FranchiseMenu.ENTITY.Enums;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace FranchiseMenu.BLL.Concrete
{
    public class FoodManager : IFoodService
    {
        private IFoodDal _foodDal;
        private ICategoryDal _categoryDal;

        public FoodManager(IFoodDal foodDal, ICategoryDal categoryDal)
        {
            _foodDal = foodDal;
            _categoryDal = categoryDal;
        }

        public IDataResult<bool> DeleteFood(int id)
        {
            try
            {
                var food = _foodDal.Get(x => x.Id == id);
                _foodDal.Delete(food);
                return new SuccessDataResult<bool>(true, "food_deleted", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unknownError);
            }
        }

        public IDataResult<bool> FoodAdd(FoodAddDto dto)
        {
            try
            {
                var food = _foodDal.Get(x => x.FoodName == dto.FoodName);
                if (food != null)
                {
                    if (food.FoodStatus == false)
                    {
                        return new ErrorDataResult<bool>(false, "food available but not active", Messages.food_available_but_not_active);
                    }
                    return new ErrorDataResult<bool>(false, "food already exists", Messages.food_already_exists);
                }
                var categoryId = _categoryDal.Get(x => x.CategoryName == dto.CategoryName).Id;
                var foodAdd = new Food
                {
                    FoodName = dto.FoodName,
                    FoodDescription = dto.FoodDescription,
                    FoodPrice = dto.FoodPrice,
                    FoodStatus = true,
                    CategoryId = categoryId,
                };
                _foodDal.Add(foodAdd);
                return new SuccessDataResult<bool>(true, "food added", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unknownError);
            }
        }

        public IDataResult<bool> FoodChangeStatus(int foodId)
        {
            try
            {


                var food = _foodDal.Get(x => x.Id == foodId);
                if (food == null)
                {
                    return new ErrorDataResult<bool>(false, "food not found", Messages.food_not_found);
                }

                if (food.FoodStatus == true)
                {
                    food.FoodStatus = false;
                    _foodDal.Update(food);
                    return new SuccessDataResult<bool>(true, "food status changed", Messages.food_status_changed);
                }
                food.FoodStatus = true;
                _foodDal.Update(food);
                return new SuccessDataResult<bool>(true, "food status changed", Messages.food_status_changed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unknownError);
            }
        }

        public IDataResult<List<FoodGetAllDto>> FoodGetAll()
        {
            try
            {
                var foods = _foodDal.GetAll();
                if (foods == null)
                {
                    return new ErrorDataResult<List<FoodGetAllDto>>(new List<FoodGetAllDto>(), "food not found", Messages.food_not_found);
                }

                var list = new List<FoodGetAllDto>();

                foreach (var item in foods)
                {
                    var categoryName = _categoryDal.Get(x => x.Id == item.CategoryId).CategoryName;
                    list.Add(new FoodGetAllDto
                    {
                        FoodDescription = item.FoodDescription,
                        FoodName = item.FoodName,
                        FoodPrice = item.FoodPrice,
                        FoodStatus = item.FoodStatus,
                        Id = item.Id,
                        CategoryId = item.CategoryId,
                        CategoryName = categoryName
                    });
                }
                return new SuccessDataResult<List<FoodGetAllDto>>(list, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<FoodGetAllDto>>(new List<FoodGetAllDto>(), e.Message, Messages.unknownError);
            }
        }

        public IDataResult<List<FoodGetByCategoryIdDto>> FoodGetByCategoryId(int categoryId, string token)
        {
            try
            {


                var foods = _foodDal.GetAll(x => x.CategoryId == categoryId).ToList();
                if (foods.Count == 0)
                {
                    return new ErrorDataResult<List<FoodGetByCategoryIdDto>>(new List<FoodGetByCategoryIdDto>(), "food not found", Messages.food_not_found);
                }

                var list = new List<FoodGetByCategoryIdDto>();

                foreach (var item in foods)
                {
                    list.Add(new FoodGetByCategoryIdDto
                    {
                        CategoryId = item.CategoryId,
                        FoodDescription = item.FoodDescription,
                        FoodName = item.FoodName,
                        FoodPrice = item.FoodPrice,
                        FoodStatus = item.FoodStatus,
                        Id = item.Id
                    });
                }
                return new SuccessDataResult<List<FoodGetByCategoryIdDto>>(list, "ok", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<FoodGetByCategoryIdDto>>(new List<FoodGetByCategoryIdDto>(), e.Message, Messages.unknownError);
            }
        }

        public IDataResult<FoodGetByIdDto> FoodGetById(int foodId, string token)
        {
            try
            {


                var food = _foodDal.Get(x => x.Id == foodId);
                if (food == null)
                {
                    return new ErrorDataResult<FoodGetByIdDto>(new FoodGetByIdDto(), "food not found", Messages.food_not_found);
                }

                var dto = new FoodGetByIdDto
                {
                    CategoryId = food.CategoryId,
                    FoodDescription = food.FoodDescription,
                    FoodName = food.FoodName,
                    FoodPrice = food.FoodPrice,
                    FoodStatus = food.FoodStatus,
                    Id = food.Id,
                };
                return new SuccessDataResult<FoodGetByIdDto>(dto, "ok", Messages.success);

            }
            catch (Exception e)
            {
                return new ErrorDataResult<FoodGetByIdDto>(new FoodGetByIdDto(), e.Message, Messages.unknownError);
            }
        }

        public IDataResult<bool> FoodUpdate(FoodUpdateDto dto)
        {


            try
            {
                var food = _foodDal.Get(x => x.Id == dto.FoodId);

                if (food == null)
                {
                    return new ErrorDataResult<bool>(false, "food not found", Messages.food_not_found);
                }

                var nameCheck = _foodDal.Get(x => x.Id != food.Id && x.FoodName == dto.FoodName);

                if (nameCheck != null)
                {
                    return new ErrorDataResult<bool>(false, "food of the same name exists", Messages.food_of_the_same_name_exists);
                }

                food.FoodStatus = dto.FoodStatus;
                food.FoodName = dto.FoodName;
                food.FoodPrice = dto.FoodPrice;
                food.FoodDescription = dto.FoodDescription;
                food.CategoryId = dto.CategoryId;

                _foodDal.Update(food);
                return new SuccessDataResult<bool>(true, "food updated", Messages.success);

            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unknownError);
            }
        }
    }
}
