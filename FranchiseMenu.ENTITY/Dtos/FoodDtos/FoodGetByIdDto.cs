using FranchiseMenu.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.ENTITY.Dtos.FoodDtos
{
    public class FoodGetByIdDto : IDto
    {
        public int Id { get; set; }
        public string? FoodName { get; set; }
        public string? FoodDescription { get; set; }
        public int FoodPrice { get; set; }
        public string? FoodImage { get; set; }
        public bool FoodStatus { get; set; }
        public int CategoryId { get; set; }
    }
}
