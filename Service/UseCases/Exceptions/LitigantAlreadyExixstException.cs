using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Exceptions
{
    public class LitigantAlreadyExixstException : Exception
    {
        public LitigantAlreadyExixstException(string message) : base(message) { }
    }
}
