using Application.Dto_s.ManagementDto_s;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ManagementCommands
{
    public class UpdatePermissionCommand : IRequest<DeleteAndUpdateValidatation>
    {
        public Guid _permissionId { get; }
        public PermissionUpdateDto _updateDto { get; }

        public UpdatePermissionCommand(Guid permissionId , PermissionUpdateDto updateDto)
        {
            _permissionId = permissionId;
            _updateDto = updateDto;
        }
    }
}
