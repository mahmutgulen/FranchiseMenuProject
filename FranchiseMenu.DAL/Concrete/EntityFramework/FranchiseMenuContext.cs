using FranchiseMenu.CORE.Entities.Concrete;
using FranchiseMenu.ENTITY.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.DAL.Concrete.EntityFramework
{
    public class FranchiseMenuContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PH12VSS;Database=FranchiseMenuProject;User Id=DESKTOP-PH12VSS\mako; integrated security=true; TrustServerCertificate=True;");

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
