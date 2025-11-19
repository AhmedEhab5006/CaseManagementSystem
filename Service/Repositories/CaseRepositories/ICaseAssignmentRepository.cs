using Application.Commons;
using Application.Dto_s;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.CaseRepositories
{
    public interface ICaseAssignmentRepository : IGenericRepository<CaseAssignment> 
    {
       public Task<PagedResult<LawyerReadDto>> GetCaseLawyersAsync(Guid caseId , int pageNumber, int pageSize, bool asNoTracking = false);
    }
}
