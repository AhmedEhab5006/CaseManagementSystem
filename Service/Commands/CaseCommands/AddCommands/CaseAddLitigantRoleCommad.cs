using Application.Dto_s.CaseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CaseCommands.AddCommands
{
    public class CaseAddLitigantRoleCommad : IRequest<bool>
    {
        public CaseLitigantRoleDto _caseLitigantRoleDto { get; }

        public CaseAddLitigantRoleCommad(CaseLitigantRoleDto caseLitigantRoleDto)
        {
            _caseLitigantRoleDto = caseLitigantRoleDto;
        }
    }
}
