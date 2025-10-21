using Application.Dto_s.CaseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.CaseQueries
{
    public class GetFullDataQuery : IRequest<CaseFullDataReadDto>
    {
        public Guid _caseId { get; }
        public GetFullDataQuery(Guid caseId)
        {
            _caseId = caseId;
        }


    }
}
