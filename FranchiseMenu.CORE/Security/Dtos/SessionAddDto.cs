using FranchiseMenu.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.CORE.Security.Dtos
{
    public class SessionAddDto : IDto
    {
        public int AdminId { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
