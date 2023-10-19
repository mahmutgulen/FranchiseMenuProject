using FranchiseMenu.CORE.Entities.Concrete;
using FranchiseMenu.CORE.Security.Dtos;
using FranchiseMenu.CORE.Utilities.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.CORE.Security
{
    public class TokenHelper : ITokenHelper
    {
        private IHttpContextAccessor _context { get; }

        public TokenHelper(IHttpContextAccessor context)
        {
            _context = context;
        }

        public IDataResult<SessionAddDto> CreateNewToken(Admin admin)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                var tokenString = HashString(guid.ToString(), "salt");

                var session = new SessionAddDto
                {
                    AdminId = admin.Id,
                    TokenString = tokenString,
                    ExpireDate = DateTime.Now.AddDays(2)
                };
                return new SuccessDataResult<SessionAddDto>(session, "Ok", "success");
            }
            catch (Exception e)
            {
                return new ErrorDataResult<SessionAddDto>(new SessionAddDto(), e.InnerException.Message, _context.HttpContext.ToString());
            }
        }


        private string HashString(string token, string salt)
        {
            using (var sha = new System.Security.Cryptography.HMACSHA256())
            {
                byte[] tokenBytes = Encoding.UTF8.GetBytes(token + salt);
                byte[] hasBytes = sha.ComputeHash(tokenBytes);

                string hash = BitConverter.ToString(hasBytes).Replace("-", string.Empty);
                return hash;
            }
        }
    }
}