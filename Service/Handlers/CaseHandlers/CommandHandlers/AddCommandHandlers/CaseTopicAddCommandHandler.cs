using Application.Commands.CaseCommands.AddCommands;
using Application.UseCases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers.CommandHandlers.AddCommandHandlers
{
    public class CaseTopicAddCommandHandler(ICaseService _caseService) : IRequestHandler<CaseTopicAddCommand, bool>
    {
        public async Task<bool> Handle(CaseTopicAddCommand request, CancellationToken cancellationToken)
        {
            var result = await _caseService.AddCaseTopicAsync(request.TopicAddDto);

            return result;
        }
    }
}
