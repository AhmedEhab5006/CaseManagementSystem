using Application.Dto_s;
using Application.Repositories.Users;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.Users
{
    public class LawyerRepository(ApplicationDbContext _applicationDbContext) : ILawyerRepository
    {
        public async Task<LawyerReadDto?> GetLawyerByIdAsync(string id)
        {
            var lawyerEntity = await _applicationDbContext.Lawyers
                                                    .AsNoTracking()        
                                                    .Where(a => a.Id == id)
                                                    .SingleOrDefaultAsync();

            if (lawyerEntity is not null)
            {
                return new LawyerReadDto
                {
                    Id = lawyerEntity.Id,
                    Name = lawyerEntity.displayName is not null ? lawyerEntity.displayName : lawyerEntity.UserName
                };
            }

            return null;
        }
    }
}
