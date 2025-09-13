using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Common
{
    public class BaseException : ApplicationException
    {
        public bool Success { get; } = false;
        public string Message { get; set; }
    }
}
