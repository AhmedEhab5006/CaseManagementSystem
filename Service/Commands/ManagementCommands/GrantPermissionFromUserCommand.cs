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
    public class GrantPermissionFromUserCommand : IRequest<DeleteAndUpdateValidatation>
    {
        public Guid _permissionId { get; }
        public string _userId { get; }
        public DeleteDto _delete { get; }

        public GrantPermissionFromUserCommand(Guid permissionId , string userId , DeleteDto deleteDto)
        {
            _delete = deleteDto;
            _permissionId = permissionId;   
            _userId = userId;
        }
    }
}
