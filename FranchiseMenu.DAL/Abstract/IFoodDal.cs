using FranchiseMenu.CORE.DataAccess.EntityFramework;
using FranchiseMenu.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.DAL.Abstract
{
    public interface IFoodDal:IEntityRepository<Food>
    {
    }
}
