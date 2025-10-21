using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.Interfaces;
using Application.Repositories;
using Application.Repositories.CaseRepositories;
using Application.Repositories.Users;
using Application.UseCases;
using AutoMapper;
using Domain.Entites;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace Infrastrcuture.Services
{
    public class CaseService(IMapper _mapper, IUnitOfWork _unitOfWork,
                                ILawyerRepository _lawyerRepository, ICacheService _cacheService) : ICaseService
    {

        #region Add Methods

        public async Task<CaseLitigantAddVaildatation> AddCaseLitigantsRangeAsync(List<CaseLtitgantDto> litigantDtos)
        {
            if (litigantDtos == null || litigantDtos.Count == 0)
                return CaseLitigantAddVaildatation.error;

            var caseIdFromCache = _cacheService.Get("currentCaseId");
            Guid? caseId = caseIdFromCache is not null ? new Guid(caseIdFromCache) : null;

            var caseLitigantEntities = new List<CaseLitigant>();

            foreach (var dto in litigantDtos)
            {
                var entity = _mapper.Map<CaseLitigant>(dto);
                entity.id = Guid.NewGuid();
                entity.createdAt = DateTime.UtcNow;
                entity.isDeleted = false;
                entity.versionNo = 1;
                entity.caseId = caseId ?? dto.caseId;

                // تحقق من وجود الكيانات المرتبطة
                var caseEntity = await _unitOfWork.CaseRepository.GetByIdAsync(entity.caseId, true);
                if (caseEntity is null)
                    return CaseLitigantAddVaildatation.casewasnotfound;

                var litigant = await _unitOfWork.LitigantRepository.GetByIdAsync(dto.litigantId, true);
                if (litigant is null)
                    return CaseLitigantAddVaildatation.litigantwasnotfound;

                var role = await _unitOfWork.CaseLitigantRoleRepository.GetByIdAsync(dto.roleId, true);
                if (role is null)
                    return CaseLitigantAddVaildatation.litigantrolewasnotfound;

                caseLitigantEntities.Add(entity);
            }

            await _unitOfWork.CaseLitigantRepository.AddRangeAsync(caseLitigantEntities);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
                return CaseLitigantAddVaildatation.done;

            return CaseLitigantAddVaildatation.error;
        }


        public async Task<CaseDocumentAddValidation> AddCaseFileAsync(CaseDocumentAddDto caseDocumentAddDto)
        {

            var caseIdFromCache = _cacheService.Get("currentCaseId");

            if (caseIdFromCache is not null)
            {
                caseDocumentAddDto.CaseId = new Guid(caseIdFromCache);
            }
            
            
            var caseDocumentEntity = new CaseDocument
            {
                CaseId = caseDocumentAddDto.CaseId,
                DocTypeId = caseDocumentAddDto.DocTypeId,
                description = caseDocumentAddDto.description,
                FileAssetId = caseDocumentAddDto.DocumentId,
                VsId = caseDocumentAddDto.VsId,
                createdAt = DateTime.UtcNow,
                versionNo = 1
            };

            
            var caseEntity = await _unitOfWork.CaseRepository.GetByIdAsync(caseDocumentAddDto.CaseId , true);
            var fileEntity = await _unitOfWork.FileRepository.GetByIdAsync(caseDocumentAddDto.DocumentId , true);
            var docTypeEntity = await _unitOfWork.CaseDocTypeRepository.GetByIdAsync(caseDocumentAddDto.DocTypeId , true);

            if (caseEntity is null)
            {
                return CaseDocumentAddValidation.CaseWasnotFound;
            }

            if (fileEntity is null)
            {
                return CaseDocumentAddValidation.FileWasnotFound;
            }

            if (docTypeEntity is null)
            {
                return CaseDocumentAddValidation.DocumentTypeWasnotFound;
            }


            await _unitOfWork.CaseDocumentRepository.AddAsync(caseDocumentEntity);
            
            if(await _unitOfWork.SaveChangesAsync() > 0)
            {
                return CaseDocumentAddValidation.Added;
            }

            return CaseDocumentAddValidation.Error;
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


            var caseType = await _unitOfWork.CaseTypeRepository.GetByIdAsync(caseEntity.caseTypeId, true);
            if (caseType is null)
            {
                return CaseAddServiceValidataion.TypeWasnnotFound;
            }


            var caseTopic = await _unitOfWork.CaseTopicRepository.GetByIdAsync(caseEntity.caseTopicId, true);
            if (caseTopic is null)
            {
                return CaseAddServiceValidataion.TopicWasnnotFound;
            }

            var court = await _unitOfWork.CourtRepository.GetByIdAsync(caseEntity.courtId, true);
            if (court is null)
            {
                return CaseAddServiceValidataion.CourtWasnnotFound;
            }



            _cacheService.Set("currentCaseId", caseEntity.id.ToString(), TimeSpan.FromHours(5));



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

        public async Task<List<Guid>> AddLitigantsRangeAsync(List<LitigantDto> litigantDtos)
        {
            if (litigantDtos == null || litigantDtos.Count == 0)
                return new List<Guid>();

            var litigantEntities = new List<Litigant>();

            foreach (var dto in litigantDtos)
            {
                var entity = _mapper.Map<Litigant>(dto);
                entity.id = Guid.NewGuid();
                entity.createdAt = DateTime.UtcNow;
                entity.isDeleted = false;
                entity.versionNo = 1;

                litigantEntities.Add(entity);
            }

            await _unitOfWork.LitigantRepository.AddRangeAsync(litigantEntities);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                return litigantEntities.Select(l => l.id).ToList();
            }

            return new List<Guid>();
        }


        public async Task<CaseAssignmentServiceValidatation> AssignCaseToLawyerAsync(IEnumerable<CaseAssignmentDto> caseAssignmentDtos)
        {
            if (caseAssignmentDtos == null || !caseAssignmentDtos.Any())
                return CaseAssignmentServiceValidatation.error;

            var caseAssignments = new List<CaseAssignment>();

            var currentCaseId = _cacheService.Get("currentCaseId");

            // Try to get the case ID once if available
            Guid? cachedCaseId = null;
            if (currentCaseId is not null && Guid.TryParse(currentCaseId, out var parsedId))
                cachedCaseId = parsedId;

            foreach (var dto in caseAssignmentDtos)
            {
                var caseAssignment = _mapper.Map<CaseAssignment>(dto);

                caseAssignment.id = Guid.NewGuid();
                caseAssignment.createdAt = DateTime.UtcNow;
                caseAssignment.isDeleted = false;
                caseAssignment.versionNo = 1;

                caseAssignment.CaseId = cachedCaseId ?? dto.CaseId;

                // Validate case existence
                var foundCase = await _unitOfWork.CaseRepository.GetByIdAsync(caseAssignment.CaseId, true);
                if (foundCase is null)
                    return CaseAssignmentServiceValidatation.casewasnnotfound;

                // Validate lawyer existence
                var foundLawyer = await _lawyerRepository.GetLawyerByIdAsync(dto.assignedUserId);
                if (foundLawyer is null)
                    return CaseAssignmentServiceValidatation.lawyerwasnnotfound;

                caseAssignments.Add(caseAssignment);
            }

            await _unitOfWork.CaseAssignmentRepository.AddRangeAsync(caseAssignments);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
                return CaseAssignmentServiceValidatation.done;

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

        public async Task<PagedResult<LawyerReadDto?>> GetCaseLawyersAsync(Guid caseId , int pageNumber , int pageSize)
        {
            var data = await _unitOfWork.CaseAssignmentRepository.GetCaseLawyersAsync(caseId , pageNumber , pageSize , true);

            if (data is not null)
            {
                return data;
            }

            return null;
        }

        public async Task<LawyerFullDataReadDto?> GetCaseLawyersFullDataAsync(string lawyerId)
        {
            var data = await _lawyerRepository.GetLawyerByIdAsync(lawyerId);

            if (data is not null)
            {
                return data;
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

        public async Task<IEnumerable<CaseDropDownMenuGetDto>?> GetCaseTopicsForDropDownMenuAsync()
        {
            var data = await _unitOfWork.CaseTopicRepository.GetAll().ToListAsync();

            if (data.Count > 0)
            {

                var types = new List<CaseDropDownMenuGetDto>();
                foreach (var type in data)
                {
                    var returnedData = new CaseDropDownMenuGetDto
                    {
                        Id = type.id,
                        Name = type.topicName
                    };

                    types.Add(returnedData);
                }

                return types;
            }

            return null;
        }

        public async Task<IEnumerable<CaseDropDownMenuGetDto>?> GetCaseTypesForDropDownMenuAsync()
        {
            var data = await _unitOfWork.CaseTypeRepository.GetAll().ToListAsync();

            if (data.Count > 0)
            {
                
                var types = new List<CaseDropDownMenuGetDto>();
                foreach(var type in data)
                {
                    var returnedData = new CaseDropDownMenuGetDto
                    {
                        Id = type.id,
                        Name = type.typeName
                    };

                    types.Add(returnedData);
                } 

                return types;
            }

            return null;
        }

        public async Task<IEnumerable<CaseDropDownMenuGetDto>?> GetCourtsForDropDownMenuAsync()
        {
            var data = await _unitOfWork.CourtRepository.GetAll().ToListAsync();

            if (data.Count > 0)
            {

                var types = new List<CaseDropDownMenuGetDto>();
                foreach (var type in data)
                {
                    var returnedData = new CaseDropDownMenuGetDto
                    {
                        Id = type.id,
                        Name = type.nameAR
                    };

                    types.Add(returnedData);
                }

                return types;
            }

            return null;
        }

        public async Task<IEnumerable<CaseDropDownMenuGetDto>?> GetLitigantsRoleDropDownMenuAsync()
        {
            var data = await _unitOfWork.CaseLitigantRoleRepository.GetAll().ToListAsync();

            if (data.Count > 0)
            {

                var roles = new List<CaseDropDownMenuGetDto>();
                foreach (var role in data)
                {
                    var returnedData = new CaseDropDownMenuGetDto
                    {
                        Id = role.id,
                        Name = role.roleName
                    };

                    roles.Add(returnedData);
                }

                return roles;
            }

            return null;
        }

        #endregion


    }
}
