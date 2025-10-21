using Application.Dto_s;
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
    public class GetLawyerPrimaryDataByIdQueryHandler(ILawyerService _lawyerService) : IRequestHandler<GetLawyerPrimaryDataByIdQuery, LawyerReadDto>
    {
        public async Task<LawyerReadDto> Handle(GetLawyerPrimaryDataByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _lawyerService.GetLawyerPrimaryDataById(request._lawyerId);
            return result;
        }
    }
}
