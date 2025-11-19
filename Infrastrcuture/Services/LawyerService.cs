using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.Audting;
using Application.Dto_s.CaseDtos;
using Application.Dto_s.Commons;
using Application.Dto_s.LawyerDto_s;
using Application.Interfaces;
using Application.Repositories;
using Application.Repositories.Auth;
using Application.Repositories.Users;
using Application.UseCases.LawyerService;
using AutoMapper;
using Domain.Entites;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services
{
    public class LawyerService(ILawyerRepository _lawyerRepository, IUnitOfWork _unitOfWork, IMapper _mapper, IAuthRepository _authRepository) : ILawyerService
    {
        public async Task<DeleteAndUpdateValidatation> AcceptCaseAssignment(Guid CaseId , string acceptedBy)
        {
            var current = await _unitOfWork.CaseRepository.GetByIdAsync(CaseId);
            if (current is not null)
            {
                current.status = CaseStatus.UnderStudy;
                current.approved = true;
                current.versionNo += 1;
                current.updatedAt = DateTime.UtcNow;
                current.updatedBy = acceptedBy;

                _unitOfWork.CaseRepository.Update(current);
                await _unitOfWork.CaseEventRepository.AddAsync(new CaseEvent
                {
                    CaseId = CaseId,
                    eventType = AudtingActions.Update.ToString(),
                    details = $"تمت الموافقة على الاسناد الاولى للدعوى من قبل المحامي {acceptedBy}",
                    createdAt = DateTime.UtcNow,
                    createdBy = acceptedBy,
                    versionNo = 1
                });

                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return DeleteAndUpdateValidatation.Done;
                }

                return DeleteAndUpdateValidatation.Error;

            }

            return DeleteAndUpdateValidatation.Done;

        }

        public async Task<DeleteAndUpdateValidatation> CloseCase(Guid caseId, CloseCaseDto close)
        {
            var caseCurrent = await _unitOfWork.CaseRepository.GetByIdAsync(caseId  , include: 
                c=>c.Include(c=>c.assignments));

            if (caseCurrent is not null && caseCurrent.assignments.Any(a=>a.assignedUserId == close.lawyerId))
            {
                caseCurrent.status = CaseStatus.Closed;
                caseCurrent.EndReport = close.breif;
                caseCurrent.updatedAt = DateTime.Now;
                caseCurrent.updatedBy = close.ModifiedBy;
                caseCurrent.versionNo += 1;

                await _unitOfWork.CaseEventRepository.AddAsync(new CaseEvent
                {
                    CaseId = caseCurrent.id,
                    eventType = AudtingActions.Update.ToString(),
                    details = $"تم اغلاق الدعوى من قبل المحامي {caseCurrent.updatedBy}",
                    createdAt = DateTime.UtcNow,
                    createdBy = close.ModifiedBy,
                    versionNo = 1
                });

                _unitOfWork.CaseRepository.Update(caseCurrent);
                if(await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return DeleteAndUpdateValidatation.Done; 
                }

                return DeleteAndUpdateValidatation.Error;

            }

            return DeleteAndUpdateValidatation.DoesnotExist;

        }

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

        public async Task<PagedResult<CaseReadDto>> GetMyAssignedCases(string lawyerId, int pageNumber, int pageSize)
        {
            var caseAssignments = await _unitOfWork.CaseAssignmentRepository
                .GetByPropertyAsync("assignedUserId", lawyerId , c=>c.Case);

            if (caseAssignments == null || !caseAssignments.Any())
            {
                return new PagedResult<CaseReadDto>
                {
                    Data = Enumerable.Empty<CaseReadDto>(),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = 0
                };
            }

            var cases = new List<CaseAssignment>();

            foreach (var assignment in caseAssignments)
            {
                if (assignment.Case.status == CaseStatus.Registered && assignment.Case.ReAssign == false)
                {
                    cases.Add(assignment);
                }
            }

            var caseIds = cases
                .Where(ca => ca != null)
                .Select(ca => ca.CaseId)
                .Distinct()
                .ToList();

            var returnedEntity = new List<Case>();

            foreach (var caseId in caseIds)
            {
                var caseEntity = await _unitOfWork.CaseRepository.GetByIdAsync(
                    caseId,
                    true,
                    c => c.Include(c => c.court)
                          .Include(c => c.court.courtGrade)
                          .Include(c => c.caseTopic)
                          .Include(c => c.caseType)
                );

                if (caseEntity != null)
                {
                    returnedEntity.Add(caseEntity);
                }
            }

            var caseReadDtos = _mapper.Map<IEnumerable<CaseReadDto>>(returnedEntity);
            var totalRecords = caseReadDtos.Count();

            var pagedData = caseReadDtos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<CaseReadDto>
            {
                Data = pagedData,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };
        }

        public async Task<PagedResult<CaseReadDto>> GetMyCurrentlyWoringCases(string lawyerId, int pageNumber, int pageSize)
        {
            var caseAssignments = await _unitOfWork.CaseAssignmentRepository
                           .GetByPropertyAsync("assignedUserId", lawyerId, c => c.Case);

            if (caseAssignments == null || !caseAssignments.Any())
            {
                return new PagedResult<CaseReadDto>
                {
                    Data = Enumerable.Empty<CaseReadDto>(),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = 0
                };
            }

            var cases = new List<CaseAssignment>();

            foreach (var assignment in caseAssignments)
            {
                if (assignment.Case.status == CaseStatus.UnderStudy && assignment.Case.ReAssign == false)
                {
                    cases.Add(assignment);
                }
            }

            var caseIds = cases
                .Where(ca => ca != null)
                .Select(ca => ca.CaseId)
                .Distinct()
                .ToList();

            var returnedEntity = new List<Case>();

            foreach (var caseId in caseIds)
            {
                var caseEntity = await _unitOfWork.CaseRepository.GetByIdAsync(
                    caseId,
                    true,
                    c => c.Include(c => c.court)
                          .Include(c => c.court.courtGrade)
                          .Include(c => c.caseTopic)
                          .Include(c => c.caseType)
                );

                if (caseEntity != null)
                {
                    returnedEntity.Add(caseEntity);
                }
            }

            var caseReadDtos = _mapper.Map<IEnumerable<CaseReadDto>>(returnedEntity);
            var totalRecords = caseReadDtos.Count();

            var pagedData = caseReadDtos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<CaseReadDto>
            {
                Data = pagedData,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };
        }

        public async Task<PagedResult<CaseReAssignmentRequestsReadDto>> GetMyReAssignmentRequests(string Id , int pageNumber , int pageSize)
        {
            var request = await _unitOfWork.CaseReAssignmentRequestRepository.GetByPropertyAsync("AssignerId", Id);
            var cases = new List<CaseReAssignmentRequestsReadDto>();
            
            if (request.Any())
            {
                foreach (var item in request) {
                    var Case = await _unitOfWork.CaseRepository.GetByIdAsync(item.CaseId , true ,include: c=>c.Include(c=>c.caseTopic));
                    var lawyer = await _authRepository.GetByIdAsync(item.AssigneeId);

                    var requestReturn = new CaseReAssignmentRequestsReadDto
                    {
                        State = item.RequestStatus,
                        CaseId = Case.id,
                        CaseNumber = Case.caseNumber,
                        CaseTitle = Case.caseTopic.topicName,
                        NewLawyerName = lawyer.DisplayName,
                        RejectionReason = item.RejectionReason,
                        RequestDate = item.createdAt,
                        RequestId = item.id,
                    };
                    
                    cases.Add(requestReturn);
                }

                var totalRecords = cases.Count();

                var pagedData = cases
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new PagedResult<CaseReAssignmentRequestsReadDto>
                {
                    Data = pagedData,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = totalRecords
                };

            }

            return new PagedResult<CaseReAssignmentRequestsReadDto>
            {
                Data = Enumerable.Empty<CaseReAssignmentRequestsReadDto>(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = 0
            };


        }

        public async Task<DeleteAndUpdateValidatation> RevokeReAssignmentRequests(Guid requestId, string assignerId, DeleteDto delete)
        {
            var request = await _unitOfWork.CaseReAssignmentRequestRepository.GetByIdAsync(requestId);
            if (request is not null)
            {
                if (request.AssignerId == assignerId && request.RequestStatus == CaseReAssignmentRequestStates.Pending)
                {
                    request.isDeleted = true;
                    request.deletionReason = delete.DeletionReason;
                    request.deletedAt = DateTime.UtcNow;
                    request.deletedBy = delete.DeletedBy;

                    _unitOfWork.CaseReAssignmentRequestRepository.Update(request);
                    await _unitOfWork.CaseEventRepository.AddAsync(new CaseEvent
                    {
                        CaseId = request.CaseId,
                        eventType = AudtingActions.Update.ToString(),
                        details = $"تم سحب طلب اعادة الاسناد المقدم من قبل المحامي {delete.DeletedBy}",
                        createdAt = DateTime.UtcNow,
                        createdBy = delete.DeletedBy,
                        versionNo = 1
                    });

                    if (await _unitOfWork.SaveChangesAsync() > 0)
                    {
                        return DeleteAndUpdateValidatation.Done;
                    }

                    return DeleteAndUpdateValidatation.Error;
                }

            }
            return DeleteAndUpdateValidatation.DoesnotExist;
        }

        public async Task<CaseReAssignmentValidation> SendCaseReAssignmentRequest(CaseReAssignmentRequestDto dto)
        {
            var assignee = await _authRepository.GetByIdAsync(dto.AssigneeId);
            if (assignee == null)
            {
                return CaseReAssignmentValidation.AssigneeNotFound;
            }


            var caseAssignment = await _unitOfWork.CaseAssignmentRepository.GetByPropertyAsync("CaseId", dto.CaseId);
            
            if (caseAssignment == null)
            {
                return CaseReAssignmentValidation.CaseNotFound;
            }

            var assigns = 0;
            foreach (var assign in caseAssignment)
            {
                if(assign.assignedUserId == dto.AssignerId)
                {
                    assigns ++;
                }

            }

            if (assigns == 0)
            {
                return CaseReAssignmentValidation.ArenotAssignedToCase;
            }

            var caseEntity = await _unitOfWork.CaseRepository.GetByIdAsync(dto.CaseId, true);
            if (caseEntity == null)
            {
                return CaseReAssignmentValidation.CaseNotFound;
            }

            var filters = new Dictionary<string, object>
            {
                { "CaseId", dto.CaseId },
                { "assignedUserId", dto.AssigneeId }
            };
            
            var existingAssignments = await _unitOfWork.CaseAssignmentRepository.GetManyByPropertiesAsync(filters);
            if (existingAssignments != null && existingAssignments.Any())
            {
                return CaseReAssignmentValidation.AssigneeAlreadyExists;
            }

            var caseReAssignmentRequest = _mapper.Map<CaseReAssignmentRequest>(dto);
            
            caseReAssignmentRequest.id = Guid.NewGuid();
            caseReAssignmentRequest.createdAt = DateTime.UtcNow;
            caseReAssignmentRequest.isDeleted = false;
            caseReAssignmentRequest.versionNo = 1;
            caseReAssignmentRequest.RequestStatus = CaseReAssignmentRequestStates.Pending;
            caseEntity.ReAssign = true;

            await _unitOfWork.CaseReAssignmentRequestRepository.AddAsync(caseReAssignmentRequest);
            await _unitOfWork.CaseEventRepository.AddAsync(new CaseEvent
            {
                CaseId = dto.CaseId,
                eventType = AudtingActions.Update.ToString(),
                details = $"تقديم طلب اعادة اسناد من قبل المحامي {dto.createdBy}",
                createdAt = DateTime.UtcNow,
                createdBy = dto.createdBy,
                versionNo = 1
            });


            var result = await _unitOfWork.SaveChangesAsync();
            
            if (result > 0)
            {
                return CaseReAssignmentValidation.Done;
            }

            return CaseReAssignmentValidation.Error;
        }
    }
}
