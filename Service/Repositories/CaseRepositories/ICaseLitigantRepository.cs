using Application.Commons;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Repositories.IGenericRepository;


namespace Application.Repositories.CaseRepositories
{
    public interface ICaseLitigantRepository : IGenericRepository<CaseLitigant>
    {
        public Task<PagedResult<CaseLitigant>> GetCaseLitigantsAsync(Guid caseId, int pageNumber, int pageSize);    
    }
}
