using FranchiseMenu.BLL.Abstract;
using FranchiseMenu.BLL.Contants;
using FranchiseMenu.CORE.Utilities.Result;
using FranchiseMenu.DAL.Abstract;
using FranchiseMenu.ENTITY.Dtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IAdminDal _adminDal;

        public AuthManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public IDataResult<bool> Login(AdminLoginDto dto)
        {
            try
            {
                var adminCheck = _adminDal.Get(x => x.AdminEmail == dto.AdminEmail);
                if (adminCheck == null)
                {
                    return new ErrorDataResult<bool>(false, "admin_not_found", Messages.admin_not_found);
                }
                if (adminCheck.AdminPassword != dto.AdminPassword)
                {
                    return new ErrorDataResult<bool>(false, "wrong_password", Messages.admin_wrong_password);
                }
                return new SuccessDataResult<bool>(true);
            }
            catch (Exception e)
            {
                return new SuccessDataResult<bool>(false, e.Message, Messages.unknownError);
            }
        }
    }
}
