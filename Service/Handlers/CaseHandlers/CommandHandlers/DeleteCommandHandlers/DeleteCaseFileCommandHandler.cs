using Application.Commands.CaseCommands.DeleteCommands;
using Application.UseCases;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers.CommandHandlers.DeleteCommandHandlers
{
    public class DeleteCaseFileCommandHandler : IRequestHandler<DeleteCaseFileCommand, DeleteAndUpdateValidatation>
    {
        private readonly ICaseService _caseService;

        public DeleteCaseFileCommandHandler(ICaseService caseService)
        {
            _caseService = caseService;
        }

        public async Task<DeleteAndUpdateValidatation> Handle(DeleteCaseFileCommand request, CancellationToken cancellationToken)
        {
            var result = await _caseService.DeleteFile(request.FileId, request.DeleteDto);
            return result;
        }
    }
}
