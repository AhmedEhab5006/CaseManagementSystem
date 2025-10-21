using Application.Dto_s.CaseDtos;
using Application.Dto_s.File;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CaseCommands.AddCommands
{
    public class CaseDocsAddCommand : IRequest<CaseDocumentAddValidation>
    {
        public CaseDocumentAddDto CaseDocumentAdd { get;}

        public CaseDocsAddCommand(CaseDocumentAddDto caseDocumentAddDto)
        {
            CaseDocumentAdd = caseDocumentAddDto;

        }
    }
}
