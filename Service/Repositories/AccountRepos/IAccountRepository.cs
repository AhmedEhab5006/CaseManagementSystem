using Application.Dto_s;
using Application.Dto_s.AccountDto_s;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Repositories.IGenericRepository;

namespace Application.Repositories.AccountRepos
{
    public interface IAccountRepository 
    {
        public Task<AccountReadDto?> GetAccountInfo(string accountId);
        public Task<EditValidatation> EditAccountInfo(string accountId , AccountEditDto account);
    }
}
