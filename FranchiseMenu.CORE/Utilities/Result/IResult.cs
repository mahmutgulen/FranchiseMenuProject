using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.CORE.Utilities.Result
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        string MessageCode { get; }
    }
}
