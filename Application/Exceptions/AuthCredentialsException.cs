using Application.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class AuthCredentialsException : BaseException
    {
        public List<string> IncorrectCredentials { get; set; } = new List<string>();
    }
}
