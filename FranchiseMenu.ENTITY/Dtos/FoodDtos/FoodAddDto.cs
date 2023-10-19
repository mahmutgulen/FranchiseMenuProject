using FranchiseMenu.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.ENTITY.Dtos.FoodDtos
{
    public class FoodAddDto : IDto
    {
        public string? FoodName { get; set; }
        public string? FoodDescription { get; set; }
        public int FoodPrice { get; set; }
        public string? CategoryName { get; set; }
    }
}
