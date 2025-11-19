using Application.Dto_s.Commons;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CaseCommands.DeleteCommands
{
    public class DeleteCaseFileCommand : IRequest<DeleteAndUpdateValidatation>
    {
        public Guid FileId { get; }
        public DeleteDto DeleteDto { get; }

        public DeleteCaseFileCommand(Guid fileId, DeleteDto deleteDto)
        {
            FileId = fileId;
            DeleteDto = deleteDto;
        }
    }
}
