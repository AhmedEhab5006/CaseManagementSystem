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
    public class AddUserCommand : IRequest<AddValidation> 
    {
        public UserAddDto _userAddDto { get; }

        public AddUserCommand(UserAddDto userAddDto)
        {
            _userAddDto = userAddDto;
        }   
    }
}

