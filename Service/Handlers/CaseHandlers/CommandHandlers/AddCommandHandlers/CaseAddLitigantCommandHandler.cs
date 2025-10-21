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
    public class CaseAddLitigantCommandHandler(ICaseService _caseService) : IRequestHandler<CaseAddLitigantCommand, List<Guid>>
    {
        public async Task<List<Guid>> Handle(CaseAddLitigantCommand request, CancellationToken cancellationToken)
        {
            var result = await _caseService.AddLitigantsRangeAsync(request._litigants);

            if (result.Count() > 0)
            {
                return result;
            }

            return null;
        }
    }
}
