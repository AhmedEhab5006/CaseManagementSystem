using Application.Dto_s.AccountDto_s;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.AccountQueries
{
    public class GetAccountDataQuery : IRequest<AccountReadDto>
    {
        public string _userId { get;  }

        public GetAccountDataQuery(string userId)
        {
            _userId = userId;
        }
    }
}
