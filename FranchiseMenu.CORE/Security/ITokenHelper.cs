using FranchiseMenu.CORE.Entities.Concrete;
using FranchiseMenu.CORE.Security.Dtos;
using FranchiseMenu.CORE.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.CORE.Security
{
    public interface ITokenHelper
    {
        IDataResult<SessionAddDto> CreateNewToken(Admin admin);
    }
}
