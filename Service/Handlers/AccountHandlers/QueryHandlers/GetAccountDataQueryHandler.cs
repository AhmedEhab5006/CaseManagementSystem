using Application.Dto_s.AccountDto_s;
using Application.Interfaces.AccountService;
using Application.Queries.AccountQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.AccountHandlers.QueryHandlers
{
    public class GetAccountDataQueryHandler(IAccountService _accountService) : IRequestHandler<GetAccountDataQuery, AccountReadDto>
    {
        public async Task<AccountReadDto> Handle(GetAccountDataQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountService.GetAccountInfo(request._userId);
            return account;
        }
    }
}
