using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        internal InfrastructureException()
        {
        }

        internal InfrastructureException(string message)
            : base(message)
        {
        }

        internal InfrastructureException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
