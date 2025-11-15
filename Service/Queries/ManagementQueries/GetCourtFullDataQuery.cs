using Application.Dto_s.CourtDto_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ManagementQueries
{
    public class GetCourtFullDataQuery : IRequest<CourtFullDataReadDto>
    {
        public Guid _courtId { get; }

        public GetCourtFullDataQuery(Guid courtId)
        {
            _courtId = courtId;
        }
    }
}

