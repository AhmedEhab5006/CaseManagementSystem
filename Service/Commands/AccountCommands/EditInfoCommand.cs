using Application.Dto_s.AccountDto_s;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AccountCommands
{
    public class EditInfoCommand : IRequest<EditValidatation>
    {
        public AccountEditDto _accountEdit { get; }
        public string _id { get; }

        public EditInfoCommand(AccountEditDto accountEdit , string id)
        {
            _accountEdit = accountEdit;
            _id = id;
        }
    }
}
