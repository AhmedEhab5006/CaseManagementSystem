using Application.Dto_s.CaseDtos;
using Application.Queries.CaseQueries;
using Application.UseCases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers.QueryHandlers
{
    public class GetCaseLawyersFullDataQueryHandler(ICaseService _caseService) : IRequestHandler<GetLawyersFullDataQuery, LawyerFullDataReadDto>
    {
        public async Task<LawyerFullDataReadDto> Handle(GetLawyersFullDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetCaseLawyersFullDataAsync(request._lawyerId);
            return result;
        }
    }
}
