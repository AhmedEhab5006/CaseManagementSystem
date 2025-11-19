using Application.Dto_s.LawyerDto_s;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.LawyerCommands
{
    public class CloseCaseCommand : IRequest<DeleteAndUpdateValidatation>
    {
        public Guid CaseId { get; }
        public CloseCaseDto CloseData { get; }

        public CloseCaseCommand(Guid caseId, CloseCaseDto closeData)
        {
            CaseId = caseId;
            CloseData = closeData;
        }
    }
}
