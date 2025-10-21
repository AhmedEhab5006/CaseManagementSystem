using Application.Dto_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.LawyerQueries
{
    public class GetLawyerPrimaryDataByIdQuery : IRequest<LawyerReadDto>
    {
        public string _lawyerId { get; }
        public GetLawyerPrimaryDataByIdQuery(string lawyerId)
        {
            _lawyerId = lawyerId;
        }
    }
}
