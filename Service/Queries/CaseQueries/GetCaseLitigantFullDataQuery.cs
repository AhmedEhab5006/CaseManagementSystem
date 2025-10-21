using Application.Dto_s.CaseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.CaseQueries
{
    public class GetCaseLitigantFullDataQuery : IRequest<LitigantDto>
    {
        public Guid _litigantId { get; }
        public GetCaseLitigantFullDataQuery(Guid litigantId)
        {
            _litigantId = litigantId;
        }
    }
}
