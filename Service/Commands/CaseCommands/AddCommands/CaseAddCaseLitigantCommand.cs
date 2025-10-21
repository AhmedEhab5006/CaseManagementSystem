using Application.Dto_s.CaseDtos;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CaseCommands.AddCommands
{
    public class CaseAddCaseLitigantCommand : IRequest<CaseLitigantAddVaildatation>
    {
        public List<CaseLtitgantDto> _caseLtitgantDto { get; }

        public CaseAddCaseLitigantCommand(List <CaseLtitgantDto> caseLtitgantDto)
        {
            _caseLtitgantDto = caseLtitgantDto;
        }
    }
}
