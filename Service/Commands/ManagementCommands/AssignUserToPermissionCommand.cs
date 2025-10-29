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
    public class AssignUserToPermissionCommand : IRequest<AssignValdiation>
    {
        public PermissionAssignmentDto _assign { get; }

        public AssignUserToPermissionCommand(PermissionAssignmentDto permissionAssignment)
        {
            _assign = permissionAssignment;
        }
    }
}
