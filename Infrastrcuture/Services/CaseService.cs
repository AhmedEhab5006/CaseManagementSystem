using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.Audting;
using Application.Dto_s.CaseDtos;
using Application.Dto_s.Commons;
using Application.Interfaces;
using Application.Repositories;
using Application.Repositories.Auth;
using Application.Repositories.CaseRepositories;
using Application.Repositories.Commons;
using Application.Repositories.Users;
using Application.UseCases;
using Application.UseCases.Exceptions;
using AutoMapper;
using Domain.Entites;
using Domain.Enums;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Net.Mail;

namespace Infrastrcuture.Services
{
    public class CaseService(IMapper _mapper, IUnitOfWork _unitOfWork,
                                ICacheService _cacheService , 
                                IAuthRepository _authRepository , IRefernceDataRepostiory _refernceDataRepostiory) : ICaseService
    {

        #region Add Methods

        public async Task<CaseLitigantAddVaildatation> AddCaseLitigantsRangeAsync(List<CaseLtitgantDto> litigantDtos)
        {
            if (litigantDtos == null || litigantDtos.Count == 0)
                return CaseLitigantAddVaildatation.error;

            var caseIdFromCache = _cacheService.Get("currentCaseId");
            
            Guid caseId = caseIdFromCache is not null ? new Guid(caseIdFromCache) : litigantDtos.FirstOrDefault().caseId;

            var caseLitigantEntities = new List<CaseLitigant>();

            foreach (var dto in litigantDtos)
            {
                var entity = _mapper.Map<CaseLitigant>(dto);
                entity.id = Guid.NewGuid();
                entity.createdAt = DateTime.UtcNow;
                entity.isDeleted = false;
                entity.versionNo = 1;
                entity.caseId = caseId != null ? caseId : dto.caseId;



                var caseEntity = await _unitOfWork.CaseRepository.GetByIdAsync(entity.caseId, true);
                if (caseEntity is null)
                    return CaseLitigantAddVaildatation.casewasnotfound;

                var litigant = await _unitOfWork.LitigantRepository.GetByIdAsync(dto.litigantId, true);
                if (litigant is null)
                    return CaseLitigantAddVaildatation.litigantwasnotfound;

                var current = await _unitOfWork.CaseLitigantRepository.GetManyByPropertiesAsync(
               new Dictionary<string, object>{
                      {"caseId" , dto.caseId } ,
                      {"litigantId" , dto.litigantId }});

                if (current.Any())
                {
                    return CaseLitigantAddVaildatation.AlreadyExixts;
                }


                var litigantName = await _unitOfWork.LitigantRepository.GetManyByPropertiesAsync(
                new Dictionary<string, object>{
                    {"firstNameAR" , litigant.firstNameAR } ,
                    {"lastNameAR" , litigant.lastNameAR } ,
                    {"firstNameEN" , litigant.firstNameEN },
                    { "lastNameEN" , litigant.lastNameEN }
                } , c => c.CaseLitigants);


                var currentOne = litigantName.MaxBy(a=>a.createdAt);
                foreach(var item in litigantName)
                {
                    if (item.CaseLitigants
                        .Select(a => a.litigantId)
                        .Contains(item.id) && item.CaseLitigants
                        .Select(a=>a.caseId).Contains(caseId)){


                        _unitOfWork.LitigantRepository.Remove(currentOne);
                        await _unitOfWork.SaveChangesAsync();
                        return CaseLitigantAddVaildatation.AlreadyExixts;


                    }

                }            


                var role = await _unitOfWork.CaseLitigantRoleRepository.GetByIdAsync(dto.roleId, true);
                if (role is null)
                    return CaseLitigantAddVaildatation.litigantrolewasnotfound;

                caseLitigantEntities.Add(entity);
            }

            await _unitOfWork.CaseLitigantRepository.AddRangeAsync(caseLitigantEntities);
            
            if(caseIdFromCache is not null)
            {
                await _unitOfWork.CaseEventRepository.AddAsync(new CaseEvent
                {
                    CaseId = caseId,
                    eventType = AudtingActions.Insert.ToString(),
                    details = "تسجيل بيانات الدعوى في النظام وعمل اسناد اولي للمحامي المختص",
                    createdAt = DateTime.UtcNow,
                    createdBy = litigantDtos.FirstOrDefault().createdBy,
                    versionNo = 1
                });

            }

            await _unitOfWork.CaseEventRepository.AddAsync(new CaseEvent
            {
                CaseId = caseId,
                eventType = AudtingActions.Update.ToString(),
                details = "اضافة طرف جديد للدعوى",
                createdAt = DateTime.UtcNow,
                createdBy = litigantDtos.FirstOrDefault().createdBy,
                versionNo = 1
            });



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
                versionNo = 1,
                createdBy= caseDocumentAddDto.createdBy,
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



            _cacheService.Set("currentCaseId", caseEntity.id.ToString(), TimeSpan.FromMinutes(15));



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

            Guid? cachedCaseId = null;
            if (currentCaseId is not null && Guid.TryParse(currentCaseId, out var parsedId))
                cachedCaseId = parsedId;

            foreach (var dto in caseAssignmentDtos)
            {
                var caseAssignment = _mapper.Map<CaseAssignment>(dto);

                var current = await _unitOfWork.CaseAssignmentRepository.GetManyByPropertiesAsync(
                  new Dictionary<string, object>{
                      {"CaseId" , dto.CaseId } ,
                      {"assignedUserId" , dto.assignedUserId }
                        });

                if (current.Any())
                {
                    return CaseAssignmentServiceValidatation.AlreadyAssigned;
                }


                caseAssignment.id = Guid.NewGuid();
                caseAssignment.createdAt = DateTime.UtcNow;
                caseAssignment.isDeleted = false;
                caseAssignment.versionNo = 1;

               

                caseAssignment.CaseId = cachedCaseId ?? dto.CaseId;

                var foundCase = await _unitOfWork.CaseRepository.GetByIdAsync(caseAssignment.CaseId, true);
                if (foundCase is null)
                    return CaseAssignmentServiceValidatation.casewasnnotfound;

                var foundLawyer = await _authRepository.GetByIdAsync(dto.assignedUserId);
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
            var data = await _authRepository.GetByIdAsync(lawyerId);
            var LawyerCases = await _unitOfWork.CaseAssignmentRepository.GetByPropertyAsync("assignedUserId", lawyerId);
            int numberOfClosedCases = 0;
            int numberOfCurrentCases = 0;
            int numberOfPendingCases = 0;
            int numberOfActiveCases = 0;

            if (LawyerCases.Any())
            {
                foreach (var c in LawyerCases)
                {
                    var currentCase = await _unitOfWork.CaseRepository.GetByIdAsync(c.CaseId);
                    if (currentCase.status == CaseStatus.Closed)
                    {
                        numberOfClosedCases += 1;
                    }

                    if (currentCase.status == CaseStatus.UnderStudy)
                    {
                        numberOfCurrentCases += 1;
                        numberOfActiveCases += 1;

                    }


                    if (currentCase.status == CaseStatus.Registered)
                    {
                        numberOfPendingCases += 1;
                        numberOfCurrentCases += 1;


                    }
                }
            }


            var lawyer = new LawyerFullDataReadDto
            {
                creator = data.CreatedBy.ToString(),
                creationDate = data.CreatedAt.ToString(),
                Email = data.Email,
                Id = data.Id,
                modificationDate = data.ModifiedAt != null ? data.ModifiedAt.ToString() : "لم يتم التعديل بعد" ,
                modifier = data.ModifiedBy != null ? data.ModifiedBy.ToString() : "لم يتم التعديل بعد",
                Name = data.DisplayName,
                numberOfClosedCases = numberOfClosedCases,
                numberOfCurrentCases = numberOfCurrentCases,
                numberOfPendingCases = numberOfPendingCases,
                phoneNumber = !string.IsNullOrEmpty(data.PhoneNumber) ? data.PhoneNumber : "لم تتم اضافة رقم الهاتف" ,
                UserName = data.UserName,
            } ;

            if (data is not null)
            {
                return lawyer;
            }

            return null;
        }

        public async Task<LitigantDto?> GetCaseLitigantFullDataAsync(Guid litigantId)
        {
            var result = await _unitOfWork.LitigantRepository.GetByIdAsync(litigantId);
            var caseLitigant = await _unitOfWork.CaseLitigantRepository.GetByPropertyAsync("litigantId", litigantId);
            var role = await _unitOfWork.CaseLitigantRoleRepository.GetByIdAsync(caseLitigant.FirstOrDefault().roleId);
            var roleName = role.roleName;

            if (result is not null)
            {
                var mapped = _mapper.Map<LitigantDto>(result);
                mapped.Type = roleName;
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

        public async Task<IEnumerable<CaseDropDownMenuGetDto>> GetAvailableCrimesAsync()
        {
            var crimes = await _refernceDataRepostiory.GetCrimesAsync();
            var returnedData = new List<CaseDropDownMenuGetDto>();

            foreach(var crime in crimes)
            {
                var dto = new CaseDropDownMenuGetDto
                {
                    Id = crime.id,
                    Name = crime.ValueAr
                };

                returnedData.Add(dto);
            }

            return returnedData;

        }

        public async Task<AddCrimeValidations> AddCrimeToLitigantAsync(CrimeAddDto crimeAdd)
        {
            var Case = await _unitOfWork.CaseRepository.GetByIdAsync(crimeAdd.CaseId); 
            var litigant = await _unitOfWork.LitigantRepository.GetByIdAsync(crimeAdd.LitigantId);
            var Crime = await _refernceDataRepostiory.GetByIdAsync(crimeAdd.CrimeId);

            if (crimeAdd.PenaltyId != null) {
                var penalty = await _refernceDataRepostiory.GetByIdAsync(crimeAdd.PenaltyId);
                if (penalty == null)
                {
                    return AddCrimeValidations.PenaltyNotFound;
                }
            }

            if (Case == null)
            {
                return AddCrimeValidations.CaseNotFound;
            }

            if (litigant == null)
            {
                return AddCrimeValidations.LitigantNotFound;
            }

            if (Crime == null)
            {
                return AddCrimeValidations.CrimeNotFound;
            }


            var exists = await _unitOfWork.LitigantCrimeRepository.GetByPropertyAsync("LitigantId", crimeAdd.LitigantId);
            if (exists is not null)
            {
                foreach (var item in exists)
                {
                    if (item.CrimeId == crimeAdd.CrimeId)
                    {
                        return AddCrimeValidations.CrimeAlreadyAdded;
                    }

                    if (item.PenaltyId == crimeAdd.PenaltyId)
                    {
                        return AddCrimeValidations.PenaltyAlreadyAdded;
                    }
                }
            }

            

            await _unitOfWork.LitigantCrimeRepository.AddAsync(new LitigantCrime
            {
                CaseId = crimeAdd.CaseId,
                PenaltyId = crimeAdd.PenaltyId,
                LitigantId = crimeAdd.LitigantId,
                CrimeId = crimeAdd.CrimeId,
                createdAt = DateTime.Now,
                createdBy = crimeAdd.createdBy,
            });


            await _unitOfWork.CaseEventRepository.AddAsync(new CaseEvent
            {
                CaseId = crimeAdd.CaseId,
                eventType = AudtingActions.Update.ToString(),
                details = $"إضافة جريمة «{Crime.ValueAr}» للمتهم «{litigant.firstNameAR} {litigant.lastNameAR}»",
                createdAt = DateTime.UtcNow,
                createdBy = crimeAdd.createdBy,
                versionNo = 1
            });

            if (await _unitOfWork.SaveChangesAsync() > 0)
            {
                return AddCrimeValidations.Added;
            }

            return AddCrimeValidations.Error;
            
        }

        public async Task<PagedResult<CrimeReadDto>> GetLitigantCrimesInCase(Guid litigantId, Guid CaseId , int pageNumber , int pageSize)
        {
            var crimes = await _unitOfWork.LitigantCrimeRepository.GetManyByPropertiesAsync(new Dictionary<string, object> {
                { "CaseId" , CaseId },
                { "LitigantId" , litigantId }
                });

            if (crimes.Any())
            {
                var caseName = await _unitOfWork.CaseRepository.GetByIdAsync(CaseId);

                var caseCrimes = new List<CrimeReadDto>();
                foreach (var crime in crimes)
                {
                    var crimeData = await _refernceDataRepostiory.GetByIdAsync(crime.CrimeId);
                    var crimeName = crimeData.ValueAr;
                    var currentCrime = new CrimeReadDto
                    {
                        CaseId = CaseId,
                        CaseName = caseName.caseNumber,
                        ClaimDate = crime.createdAt.ToString("yyyy-MM-yy"),
                        CrimeId = crimeData.id,
                        CrimeName = crimeName,
                    };

                    caseCrimes.Add(currentCrime);
                    
                }

                var pagedData = caseCrimes
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

                return new PagedResult<CrimeReadDto>
                {
                    Data = pagedData,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = caseCrimes.Count
                };

            }

            return new PagedResult<CrimeReadDto>
            {
                Data = Enumerable.Empty<CrimeReadDto>(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = 0
            };
        }

        public async Task<PagedResult<CaseHistoryReadDto>> GetCaseHistory(Guid caseId , int pageNumber , int pageSize)
        {
            var current = await _unitOfWork.CaseEventRepository.GetByPropertyAsync("CaseId", caseId);
            if (current.Any())
            {
                var list = new List<CaseHistoryReadDto>();
                foreach(var Case in current)
                {
                    var dto = new CaseHistoryReadDto
                    {
                        ActionType = Case.eventType,
                        Actor = Case.createdBy,
                        details = Case.details,
                        time = Case.createdAt


                    };

                    list.Add(dto);

                    }

                var pagedData = list
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();

                return new PagedResult<CaseHistoryReadDto>
                {
                    Data = pagedData,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = list.Count
                };



            }

            return new PagedResult<CaseHistoryReadDto>
            {
                Data = Enumerable.Empty<CaseHistoryReadDto>(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = 0
            };
        }

        public async Task<IEnumerable<CaseDropDownMenuGetDto>?> GetDocTypesDropDownMenuAsync()
        {
            var data = await _unitOfWork.CaseDocTypeRepository.GetAll().ToListAsync();

            if (data.Count > 0)
            {

                var types = new List<CaseDropDownMenuGetDto>();
                foreach (var type in data)
                {
                    var returnedData = new CaseDropDownMenuGetDto
                    {
                        Id = type.id,
                        Name = type.Type
                    };

                    types.Add(returnedData);
                }

                return types;
            }

            return null;
        }

        public async Task<PagedResult<CaseAttachmentsReadDto>> GetCaseAttachments(Guid caseId, int pageNumber, int pageSize)
        {
            var caseDocument = await _unitOfWork.CaseDocumentRepository.GetByPropertyAsync("CaseId", caseId , c=>c.FileAsset);
            if (caseDocument.Any())
            {
                var attachments = new List<CaseAttachmentsReadDto>();
                foreach (var attachment in caseDocument)
                {
                    var dto = new CaseAttachmentsReadDto
                    {
                        CaseId = attachment.CaseId,
                        CreatedAt = attachment.createdAt.ToString("yyyy-MM-yy"),
                        FileId = attachment.FileAsset.id,
                        Description = !string.IsNullOrEmpty(attachment.description) ? attachment.description : "غير متاح",
                        UniqueNo = !string.IsNullOrEmpty(attachment.FileAsset.FileName) ? attachment.FileAsset.FileName : "غير متاح",
                        IdInCaseDocuemntTable = attachment.id,
                        VsId = !string.IsNullOrEmpty(attachment.VsId) ? attachment.VsId : "غير متاح"
                    };

                   attachments.Add(dto);
                }

                var pagedData = attachments
                 .Skip((pageNumber - 1) * pageSize)
                  .Take(pageSize)
                    .ToList();

                return new PagedResult<CaseAttachmentsReadDto>
                {
                    Data = pagedData,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = attachments.Count
                };


            }

            return new PagedResult<CaseAttachmentsReadDto>
            {
                Data = Enumerable.Empty<CaseAttachmentsReadDto>(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = 0
            };

        }

        public async Task<DeleteAndUpdateValidatation> DeleteFile(Guid fileId, DeleteDto deleteDto)
        {
            var file = await _unitOfWork.CaseDocumentRepository.GetByIdAsync(fileId ,include:  
                        c=>c.Include(c=>c.FileAsset));

            if(file is not null)
            {
                file.versionNo += 1;
                file.deletedAt = DateTime.Now;
                file.deletedBy = deleteDto.DeletedBy;
                file.deletionReason = deleteDto.DeletionReason;
                file.isDeleted = true;
                file.FileAsset.deletedAt = DateTime.Now;
                file.FileAsset.deletedBy = deleteDto.DeletedBy;
                file.FileAsset.deletionReason = deleteDto.DeletionReason;
                file.FileAsset.isDeleted = true;
                file.FileAsset.versionNo += 1;

                await _unitOfWork.CaseEventRepository.AddAsync(new CaseEvent
                {
                    CaseId = file.CaseId,
                    eventType = AudtingActions.Update.ToString(),
                    details = $"تم حذف المرفق {file.FileAsset.FileName} من قبل المستخدم {file.deletedBy}",
                    createdAt = DateTime.UtcNow,
                    createdBy = file.deletedBy,
                    versionNo = 1
                });

                _unitOfWork.CaseDocumentRepository.Update(file);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return DeleteAndUpdateValidatation.Done;
                }

                return DeleteAndUpdateValidatation.Error;

            }

            return DeleteAndUpdateValidatation.DoesnotExist;
        }

        public async Task<PagedResult<CaseReadDto>> GetClosedCases(int pageNumber, int pageSize)
        {
            var result = await _unitOfWork.CaseRepository.GetByPropertyAsync("status" , CaseStatus.Closed , 
                c=>c.caseType , 
                c=>c.caseTopic ,
                c=>c.court,
                c => c.court.courtGrade);

            if (result is not null)
            {
                var mapped = _mapper.Map<IEnumerable<CaseReadDto>>(result);

                var pagedData = mapped
                .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                   .ToList();

                return new PagedResult<CaseReadDto>
                {
                    Data = mapped,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = mapped.Count()
                };
            }

            return new PagedResult<CaseReadDto>
            {
                Data = Enumerable.Empty<CaseReadDto>(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = 0
            };
        }

        #endregion


    }
}
