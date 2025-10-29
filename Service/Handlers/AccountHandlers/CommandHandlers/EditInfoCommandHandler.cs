using Application.Commands.AccountCommands;
using Application.Interfaces.AccountService;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.AccountHandlers.CommandHandlers
{
    public class EditInfoCommandHandler(IAccountService _accountService) : IRequestHandler<EditInfoCommand, EditValidatation>
    {
        public async Task<EditValidatation> Handle(EditInfoCommand request, CancellationToken cancellationToken)
        {
            var result = await _accountService.EditAccountInfo(request._id, request._accountEdit);
            return result;
        }
    }
}
