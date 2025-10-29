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
    public class AddPermissionCommand : IRequest<PermissionAddValidation> 
    {
        public PermissionDto _add { get; }

        public AddPermissionCommand(PermissionDto permission)
        {
            _add = permission;
        }   
    }
}
