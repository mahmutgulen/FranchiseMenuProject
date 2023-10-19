using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.CORE.Entities.Concrete
{
    public class Admin : IEntity
    {
        public int Id { get; set; }
        public string? AdminName { get; set; }
        public string? AdminSurname { get; set; }
        public string? AdminEmail { get; set; }
        public string? AdminPhoneNumber { get; set; }
        public string? AdminPassword{ get; set; }
        public bool AdminStatus { get; set; }
    }
}
