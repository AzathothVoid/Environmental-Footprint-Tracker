using Application.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public string Email { get; set; }
    }
}
