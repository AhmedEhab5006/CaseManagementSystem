using Application.Commands.CaseCommands.AddCommands;
using Application.UseCases;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers.CommandHandlers.AddCommandHandlers
{
    public class CaseDocsAddCommandHandler(ICaseService _caseService) : IRequestHandler<CaseDocsAddCommand, CaseDocumentAddValidation>
    {
        public async Task<CaseDocumentAddValidation> Handle(CaseDocsAddCommand request, CancellationToken cancellationToken)
        {

            var result = await _caseService.AddCaseFileAsync(request.CaseDocumentAdd);

            return result;
        }
        }
}
