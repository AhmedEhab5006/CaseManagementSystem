using Application.Dto_s.CaseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CaseCommands.AddCommands
{
    public class CaseAddTypeCommand : IRequest<bool>
    {
        public CaseTypeAddDto _typeDto { get; }

        public CaseAddTypeCommand(CaseTypeAddDto caseTypeAddDto) {
            _typeDto = caseTypeAddDto;
        }
    }
}
