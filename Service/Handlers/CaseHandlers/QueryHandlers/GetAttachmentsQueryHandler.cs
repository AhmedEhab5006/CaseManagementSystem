using Application.Commons;
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
    public class GetAttachmentsQueryHandler : IRequestHandler<GetAttachmentsQuery, PagedResult<CaseAttachmentsReadDto>>
    {
        private readonly ICaseService _caseService;

        public GetAttachmentsQueryHandler(ICaseService caseService)
        {
            _caseService = caseService;
        }

        public async Task<PagedResult<CaseAttachmentsReadDto>> Handle(GetAttachmentsQuery request, CancellationToken cancellationToken)
        {
            return await _caseService.GetCaseAttachments(request.CaseId, request.PageNumber, request.PageSize);
        }
    }
}
