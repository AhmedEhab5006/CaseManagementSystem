using Application.Dto_s.CaseDtos;
using Application.Queries.LawyerQueries;
using Application.UseCases.LawyerService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.LawyerHandlers
{
    public class GetLawyerForDropMenuQueryHandler(ILawyerService _lawyerService) : IRequestHandler<GetLawyersForDropMenuQuery, IEnumerable<CaseDropDownMenuGetDto>>
    {
        public async Task<IEnumerable<CaseDropDownMenuGetDto>> Handle(GetLawyersForDropMenuQuery request, CancellationToken cancellationToken)
        {
            var result = await _lawyerService.GetLawyersForDropDownMenuAsync();
            return result;
        }
    }
}
