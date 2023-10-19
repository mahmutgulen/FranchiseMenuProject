using FranchiseMenu.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.ENTITY.Dtos.AuthDtos
{
    public class LoginSecurityDto : IDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
