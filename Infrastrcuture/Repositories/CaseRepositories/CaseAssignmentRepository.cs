using Application.Commons;
using Application.Dto_s;
using Application.Repositories.CaseRepositories;
using AutoMapper;
using Domain.Entites;
using Infrastrcuture.Auth;
using Infrastrcuture.Database;
using Infrastrcuture.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.CaseRepositories
{
    public class CaseAssignmentRepository(ApplicationDbContext _context , IMapper _mapper) : GenericRepository<CaseAssignment>(_context), ICaseAssignmentRepository
    {
        public async Task<PagedResult<LawyerReadDto>> GetCaseLawyersAsync(Guid caseId, int pageNumber, int pageSize, bool asNoTracking = false)
        {
            var query = _context.CasesAssignments
                                .Where(ca => ca.CaseId == caseId)
                    .Join(_context.Lawyers,
          ca => ca.assignedUserId,
          l => l.Id,
          (ca, l) => new
          {
              l.Id,
              l.Email,
              l.displayName,
              l.UserName,
              Role = ca.assignedUserRole
          });

            if (asNoTracking)
                query = query.AsNoTracking();

            var totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var returned = data.Select(item => new LawyerReadDto
            {
                Id = item.Id,
                Name = item.displayName,
                UserName = item.UserName,
                Email = item.Email,
                Role = item.Role
            }).ToList();

            return new PagedResult<LawyerReadDto>
            {
                Data = returned,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalCount
            };

        }
    }
}