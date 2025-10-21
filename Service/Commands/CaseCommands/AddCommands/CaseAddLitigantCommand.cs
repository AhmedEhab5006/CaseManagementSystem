using Application.Dto_s.CaseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CaseCommands.AddCommands
{
    public class CaseAddLitigantCommand : IRequest<List<Guid>>
    {
        public List<LitigantDto> _litigants { get; }

        public CaseAddLitigantCommand(List<LitigantDto> litigantDto) {
            _litigants = litigantDto;
        }
    }
}
