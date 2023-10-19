using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.CORE.Utilities.Result
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(bool success, string message, string messageCode, T data) : base(success, message, messageCode)
        {
            Data = data;

        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
