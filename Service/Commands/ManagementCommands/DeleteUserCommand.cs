using Application.Dto_s.Commons;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ManagementCommands
{
    public class DeleteUserCommand : IRequest<DeleteAndUpdateValidatation>
    {
        public string _userId { get; }
        public DeleteDto _delete { get; }

        public DeleteUserCommand(string userId, DeleteDto delete)
        {
            _userId = userId;
            _delete = delete;
        }
    }
}

