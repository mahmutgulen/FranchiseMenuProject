using FranchiseMenu.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.ENTITY.Dtos.AuthDtos
{
    public class RegisterForManagerDto : IDto
    {
        public string? AdminName { get; set; }
        public string? AdminSurname { get; set; }
        public string? AdminEmail { get; set; }
        public string? AdminPhoneNumber { get; set; }
        public string? AdminPassword { get; set; }
    }
}
