using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Auth
{
    public class EmailSendingFailureUseCase : Exception
    {
        public EmailSendingFailureUseCase(string message) : base(message) { }

    }
}
