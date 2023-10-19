using FranchiseMenu.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.CORE.Security.Dtos
{
    public class SessionCheckResponseDto : IDto
    {
        public bool Success { get; set; }
        public int AdminId { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
