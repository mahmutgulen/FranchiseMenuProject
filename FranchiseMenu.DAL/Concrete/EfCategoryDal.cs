using FranchiseMenu.CORE.DataAccess.EntityFramework;
using FranchiseMenu.DAL.Abstract;
using FranchiseMenu.DAL.Concrete.EntityFramework;
using FranchiseMenu.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.DAL.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, FranchiseMenuContext>, ICategoryDal
    {
    }
}
