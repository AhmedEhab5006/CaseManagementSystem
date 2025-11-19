using Application.Commons;
using Application.Dto_s.CaseDtos;
using Application.Queries.LawyerQueries;
using Application.UseCases.LawyerService;
using MediatR;

namespace Application.Handlers.LawyerHandlers
{
    public class GetCurrentCasesQueryHandler
        : IRequestHandler<GetCurrentCasesQuery, PagedResult<CaseReadDto>>
    {
        private readonly ILawyerService _lawyerService;

        public GetCurrentCasesQueryHandler(ILawyerService lawyerService)
        {
            _lawyerService = lawyerService;
        }

        public async Task<PagedResult<CaseReadDto>> Handle(
            GetCurrentCasesQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _lawyerService.GetMyCurrentlyWoringCases(
                request.LawyerId,
                request.PageNumber,
                request.PageSize
            );

            return result;
        }
    }
}
