using FranchiseMenu.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.ENTITY.Dtos.AuthDtos
{
    public class AdminLoginDto : IDto
    {
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
    }
}
