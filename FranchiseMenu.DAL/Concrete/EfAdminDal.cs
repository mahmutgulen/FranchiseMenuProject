using FranchiseMenu.CORE.DataAccess.EntityFramework;
using FranchiseMenu.CORE.Entities.Concrete;
using FranchiseMenu.DAL.Abstract;
using FranchiseMenu.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.DAL.Concrete
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin, FranchiseMenuContext>, IAdminDal
    {
    }
}
