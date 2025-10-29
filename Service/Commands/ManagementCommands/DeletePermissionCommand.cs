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
    public class DeletePermissionCommand : IRequest<DeleteAndUpdateValidatation>
    {
        public Guid _PermissionId { get; }
        public DeleteDto _Delete { get; }

        public DeletePermissionCommand(Guid PermissionId , DeleteDto deleteDto)
        {
            _PermissionId = PermissionId;
            _Delete = deleteDto;
        }
    }
}
