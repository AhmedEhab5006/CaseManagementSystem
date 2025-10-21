using Application.Dto_s.CaseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.CaseQueries
{
    public class GetLawyersFullDataQuery : IRequest<LawyerFullDataReadDto>
    {
        public string _lawyerId { get; }
        public GetLawyersFullDataQuery(string lawyerId)
        {
            _lawyerId = lawyerId;
        }

    }
}
