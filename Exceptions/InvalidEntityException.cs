using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class InvalidEntityException : ApplicationException
    {
        public InvalidEntityException()
        {
        }

        public InvalidEntityException(string message)
            : base(message)
        {
        }
    }
}
