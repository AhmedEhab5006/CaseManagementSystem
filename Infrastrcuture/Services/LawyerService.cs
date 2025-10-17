using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.Repositories.Users;
using Application.UseCases.LawyerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services
{
    public class LawyerService(ILawyerRepository _lawyerRepository) : ILawyerService
    {
        public async Task<LawyerReadDto?> GetLawyerPrimaryDataById(string id)
        {
            var data = await _lawyerRepository.GetLawyerPrimaryDataByIdAsync(id);
            
            if (data is not null)
            {
                return data;

            }

            return null;
        }

        public async Task<IEnumerable<CaseDropDownMenuGetDto?>> GetLawyersForDropDownMenuAsync()
        {
            var data = await _lawyerRepository.GetLawyersForDropDownMenuAsync();

            if (data is not null)
            {
                return data;

            }

            return null;
        }
    }
}
