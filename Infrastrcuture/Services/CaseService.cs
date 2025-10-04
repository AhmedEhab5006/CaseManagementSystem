using Application.Dto_s.CaseDtos;
using Application.Repositories;
using Application.UseCases;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services
{
    public class CaseService(IMapper _mapper , IUnitOfWork _unitOfWork) : ICaseService
    {
        public async Task<bool> AddCasePrimaryData(CaseAddDto caseAddDto)
        {
         
                var caseEntity = _mapper.Map<Case>(caseAddDto);

                caseEntity.id = Guid.NewGuid();
                caseEntity.createdAt = DateTime.UtcNow;
                caseEntity.isDeleted = false;
                caseEntity.versionNo = 1;

                await _unitOfWork.CaseRepository.AddAsync(caseEntity);

                var result = await _unitOfWork.SaveChangesAsync();

                return result > 0;
            }

        
    }
}
