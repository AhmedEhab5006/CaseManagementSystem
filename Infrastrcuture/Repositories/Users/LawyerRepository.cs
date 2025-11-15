using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.Repositories.Users;
using AutoMapper;
using Infrastrcuture.Auth;
using Infrastrcuture.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.Users
{
    public class LawyerRepository(ApplicationDbContext _applicationDbContext , IMapper _mapper , UserManager<ApplicationUser>
         _userManager) : ILawyerRepository
    {
        public async Task<LawyerFullDataReadDto?> GetLawyerByIdAsync(string id)
        {
            var lawyerEntity = await _applicationDbContext.Lawyers
                                                    .AsNoTracking()        
                                                    .Where(a => a.Id == id)
                                                    .SingleOrDefaultAsync();

            if (lawyerEntity is not null)
            {
               var returned = _mapper.Map<LawyerFullDataReadDto>(lawyerEntity);
               return returned;
            }

            return null;
        }

        public async Task<LawyerReadDto?> GetLawyerPrimaryDataByIdAsync(string id)
        {
            var lawyerEntity = await _applicationDbContext.Users
                                                               .AsNoTracking()
                                                               .Where(a => a.Id == id)
                                                               .SingleOrDefaultAsync();
            if (lawyerEntity is not null)
            {
                var returned = _mapper.Map<LawyerReadDto>(lawyerEntity);
                return returned;
            }

            return null;
        }

        public async Task<IEnumerable<CaseDropDownMenuGetDto?>> GetLawyersForDropDownMenuAsync()
        {
            var lawyerEntity = await _userManager.GetUsersInRoleAsync("Lawyer");
            
            if (lawyerEntity is not null)
            {
                var returned = new List<CaseDropDownMenuGetDto?>(); 
                
                foreach (var item in lawyerEntity) {
                    var addedItem = new CaseDropDownMenuGetDto
                    {
                        Id = new Guid(item.Id),
                        Name = item.displayName
                    };
                    returned.Add(addedItem);
                }
                return returned;
            }

            return null;
        }
    }
}
