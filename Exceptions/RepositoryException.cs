using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class RepositoryException : ApplicationException
    {
        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
