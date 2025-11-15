using Application.Commons;
using Application.Dto_s.CaseDtos;
using Application.Queries.LawyerQueries;
using Application.UseCases.LawyerService;
using MediatR;

namespace Application.Handlers.LawyerHandlers
{
    public class GetMyAssignedCasesQueryHandler
        : IRequestHandler<GetMyAssignedCasesQuery, PagedResult<CaseReadDto>>
    {
        private readonly ILawyerService _lawyerService;

        public GetMyAssignedCasesQueryHandler(ILawyerService lawyerService)
        {
            _lawyerService = lawyerService;
        }

        public async Task<PagedResult<CaseReadDto>> Handle(
            GetMyAssignedCasesQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _lawyerService.GetMyAssignedCases(
                request.LawyerId,
                request.PageNumber,
                request.PageSize
            );

            return result;
        }
    }
}
