using Application.Dto_s.CaseDtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.ManagementQueries
{
    public class GetCourtGradesForDropDownMenuQuery : IRequest<IEnumerable<CaseDropDownMenuGetDto>>
    {
    }
}

