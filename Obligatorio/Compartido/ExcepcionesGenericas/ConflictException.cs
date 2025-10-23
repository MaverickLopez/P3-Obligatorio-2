using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.ExcepcionesGenericas
{
    public class ConflictException:Exception
    {
        public ConflictException() { }
        public ConflictException(string? message, Exception? innerException) : 
            base(message, innerException)
        { }
        public ConflictException(string message):
            base(message)
        { }

    }
}
