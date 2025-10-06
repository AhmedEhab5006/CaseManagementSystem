using Application.Commons;
using Application.Dto_s.CaseDtos;
using Application.Interfaces;
using Application.Repositories;
using Application.Repositories.Users;
using Application.UseCases;
using AutoMapper;
using Domain.Entites;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcuture.Services
{
    public class CaseService(IMapper _mapper , IUnitOfWork _unitOfWork , 
                                ILawyerRepository _lawyerRepository, ICacheService _cacheService) : ICaseService
    {

        #region Add Methods

        public async Task<CaseLitigantAddVaildatation> AddCaseLitigantAsync(CaseLtitgantDto litigantDto)
        {

            var caseLitigantEntity = _mapper.Map<CaseLitigant>(litigantDto);

            caseLitigantEntity.id = Guid.NewGuid();
            caseLitigantEntity.createdAt = DateTime.UtcNow;
            caseLitigantEntity.isDeleted = false;
            caseLitigantEntity.versionNo = 1;


            var caseId = _cacheService.Get("currentCaseId");
            
            if (caseId is not null)
            {
                caseLitigantEntity.caseId = new Guid(caseId);
            }

            else
            {
                caseLitigantEntity.caseId = litigantDto.caseId;

            }


            var Case = await _unitOfWork.CaseRepository.GetByIdAsync(caseLitigantEntity.caseId, true);
            if (Case is null)
            {
                return CaseLitigantAddVaildatation.casewasnotfound;
            }


            var litigant = await _unitOfWork.LitigantRepository.GetByIdAsync(caseLitigantEntity.litigantId, true);
            if (litigant is null)
            {
                return CaseLitigantAddVaildatation.litigantwasnotfound;
            }

            var litigantRole = await _unitOfWork.CaseLitigantRoleRepository.GetByIdAsync(caseLitigantEntity.roleId, true);
            if (litigantRole is null)
            {
                return CaseLitigantAddVaildatation.litigantrolewasnotfound;
            }






            await _unitOfWork.CaseLitigantRepository.AddAsync(caseLitigantEntity);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                return CaseLitigantAddVaildatation.done;
            }

            return CaseLitigantAddVaildatation.error;
            ;
        }
        

        public async Task<bool> AddCaseLitigantRoleAsync(CaseLitigantRoleDto caseLitigantRoleDto)
        {
            var caseLitigantRoleEntity = _mapper.Map<CaseLitigantRole>(caseLitigantRoleDto);

            caseLitigantRoleEntity.id = Guid.NewGuid();
            caseLitigantRoleEntity.createdAt = DateTime.UtcNow;
            caseLitigantRoleEntity.isDeleted = false;
            caseLitigantRoleEntity.versionNo = 1;


            await _unitOfWork.CaseLitigantRoleRepository.AddAsync(caseLitigantRoleEntity);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<CaseAddServiceValidataion> AddCasePrimaryData(CaseAddDto caseAddDto)
        {
         
                var caseEntity = _mapper.Map<Case>(caseAddDto);

                caseEntity.id = Guid.NewGuid();
                caseEntity.createdAt = DateTime.UtcNow;
                caseEntity.isDeleted = false;
                caseEntity.versionNo = 1;


                var caseType = await _unitOfWork.CaseTypeRepository.GetByIdAsync(caseEntity.caseTypeId , true); 
                if(caseType is null)
                {
                    return CaseAddServiceValidataion.TypeWasnnotFound;
                }


                var caseTopic = await _unitOfWork.CaseTopicRepository.GetByIdAsync(caseEntity.caseTopicId , true);
                if (caseTopic is null)
                {
                    return CaseAddServiceValidataion.TopicWasnnotFound;
                }

                 var court = await _unitOfWork.CourtRepository.GetByIdAsync(caseEntity.courtId , true);
                 if (court is null)
                 {
                    return CaseAddServiceValidataion.CourtWasnnotFound;
                 }

            var courtGrade = await _unitOfWork.CourtGradeRepository.GetByIdAsync(caseEntity.courtGradeId, true);
            if (courtGrade is null)
            {
                return CaseAddServiceValidataion.CourtGradeWasnotFound;
            }



            _cacheService.Set("currentCaseId" , caseEntity.id.ToString(), TimeSpan.FromMinutes(30));
            
                
            
                await _unitOfWork.CaseRepository.AddAsync(caseEntity);

                var result = await _unitOfWork.SaveChangesAsync();

                if (result > 0)
            {
                return CaseAddServiceValidataion.Done;
            }

                return CaseAddServiceValidataion.Error;
            ;
            }

        public async Task<bool> AddCaseTopicAsync(CaseTopicAddDto caseTopicDto)
        {
            var caseTopicEntity = _mapper.Map<CaseTopic>(caseTopicDto);
            
            caseTopicEntity.id = Guid.NewGuid();
            caseTopicEntity.createdAt = DateTime.UtcNow;
            caseTopicEntity.isDeleted = false;
            caseTopicEntity.versionNo = 1;


            await _unitOfWork.CaseTopicRepository.AddAsync(caseTopicEntity);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddCaseTypeAsync(CaseTypeAddDto caseTypeDto)
        {
            var caseTypeEntity = _mapper.Map<CaseType>(caseTypeDto);

            caseTypeEntity.id = Guid.NewGuid();
            caseTypeEntity.createdAt = DateTime.UtcNow;
            caseTypeEntity.isDeleted = false;
            caseTypeEntity.versionNo = 1;


            await _unitOfWork.CaseTypeRepository.AddAsync(caseTypeEntity);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddLitigantAsync(LitigantDto litigantDto)
        {
            var litigantEntity = _mapper.Map<Litigant>(litigantDto);


            litigantEntity.id = Guid.NewGuid();
            litigantEntity.createdAt = DateTime.UtcNow;
            litigantEntity.isDeleted = false;
            litigantEntity.versionNo = 1;

            await _unitOfWork.LitigantRepository.AddAsync(litigantEntity);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<CaseAssignmentServiceValidatation> AssignCaseToLawyerAsync(CaseAssignmentDto caseAssignmentDto)
        {
            var caseAssignment = _mapper.Map<CaseAssignment>(caseAssignmentDto);

            caseAssignment.id = Guid.NewGuid();
            caseAssignment.createdAt = DateTime.UtcNow;
            caseAssignment.isDeleted = false;
            caseAssignment.versionNo = 1;

            var currentCaseId = _cacheService.Get("currentCaseId");
            
            
            
            
            if (currentCaseId is not null)
            {
                caseAssignment.CaseId = new Guid(currentCaseId);

            }
            else
            {
                caseAssignment.CaseId = caseAssignmentDto.CaseId;

            }

            
            var foundCase = await _unitOfWork.CaseRepository.GetByIdAsync(caseAssignment.CaseId , true);
            
            if (foundCase is null)
            {
                return CaseAssignmentServiceValidatation.casewasnnotfound;
            }

            var foundLawyer = await _lawyerRepository.GetLawyerByIdAsync(caseAssignmentDto.assignedUserId);
            if (foundLawyer is null)
            {
                return CaseAssignmentServiceValidatation.lawyerwasnnotfound;
            }

            

            await _unitOfWork.CaseAssignmentRepository.AddAsync(caseAssignment);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                return CaseAssignmentServiceValidatation.done;
            }

            return CaseAssignmentServiceValidatation.error;
            
        }


        #endregion

        #region Get Methods

        public async Task<PagedResult<CaseReadDto>> GetAllCasesMainDataAsync(int pageNumber , int pageSize)
        {
            var result = await _unitOfWork.CaseRepository.GetAllAsync(pageNumber, pageSize, true,
                        c => c.Include(c => c.court)
                               .Include(c => c.court.courtGrade)
                               .Include(c => c.caseTopic)
                                .Include(c => c.caseType));


            var mappedData = _mapper.Map<IEnumerable<CaseReadDto>>(result.Data);

            var returnedData = new PagedResult<CaseReadDto>
            {
                Data = mappedData,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalRecords = result.TotalRecords
            };

            return returnedData;

        }

        public async Task<CaseFullDataReadDto?> GetCaseAllDataAsync(Guid caseId)
        {
            var result = await _unitOfWork.CaseRepository.GetByIdAsync(caseId , true,
                                    c => c.Include(c => c.court)
                                           .Include(c => c.court.courtGrade)
                                           .Include(c => c.caseTopic)
                                            .Include(c => c.caseType))
                                                ;

            if (result is not null)
            {
                var mappedData = _mapper.Map<CaseFullDataReadDto>(result);

                return mappedData;
            }


            return null;
        }

        public async Task<LitigantDto?> GetCaseLitigantFullDataAsync(Guid litigantId)
        {
            var result = await _unitOfWork.LitigantRepository.GetByIdAsync(litigantId);

            if (result is not null)
            {
                var mapped = _mapper.Map<LitigantDto>(result);
                return mapped;
            }

            return null;
        }

        public async Task<PagedResult<LitigantReadDto?>> GetCaseLitigantsAsync(int pageNumber, int pageSize , Guid caseId)
        {
            var result = await _unitOfWork.CaseLitigantRepository.GetCaseLitigantsAsync(caseId , pageNumber , pageSize);

            if (result is not null)
            {
                var mapped  = _mapper.Map<IEnumerable<LitigantReadDto>>(result.Data);
                
                var returnedData = new PagedResult<LitigantReadDto>
                {
                    Data = mapped,
                    PageNumber = result.PageNumber,
                    PageSize = result.PageSize,
                    TotalRecords = result.TotalRecords
                };

                return returnedData;
            }

            return null;
        }


        #endregion


    }
}
