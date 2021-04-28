using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLayer
{
    public class ELibraryException : ApplicationException
    {
        public ELibraryException()
        {

        }

        public ELibraryException(string message) : base(message)
        {

        }

        public ELibraryException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
