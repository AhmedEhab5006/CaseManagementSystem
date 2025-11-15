using Application.Dto_s.CourtDto_s;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ManagementCommands
{
    public class CourtAddCommand : IRequest<AddValidation>
    {
        public CourtAddDto _courtAddDto { get; }

        public CourtAddCommand(CourtAddDto courtAddDto)
        {
            _courtAddDto = courtAddDto;
        }
    }
}

