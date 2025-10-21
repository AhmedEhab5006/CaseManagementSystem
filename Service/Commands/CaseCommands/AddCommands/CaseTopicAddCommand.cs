using Application.Dto_s.CaseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CaseCommands.AddCommands
{
    public class CaseTopicAddCommand : IRequest<bool>
    {
        public CaseTopicAddDto TopicAddDto { get; }

        public CaseTopicAddCommand(CaseTopicAddDto TopicAdd)
        {
            TopicAddDto = TopicAdd;
        }
    }
}
