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
    public class GrantPermissionFromRoleCommand : IRequest<DeleteAndUpdateValidatation>
    {
        public Guid _permissionId { get; }
        public string _roleId { get; }
        public DeleteDto _delete { get; }

        public GrantPermissionFromRoleCommand(Guid permissionId , string roleId , DeleteDto deleteDto)
        {
            _delete = deleteDto;
            _permissionId = permissionId;
            _roleId = roleId;
        }
    }
}
