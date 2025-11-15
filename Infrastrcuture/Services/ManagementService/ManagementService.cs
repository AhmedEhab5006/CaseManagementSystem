using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.Dto_s.Commons;
using Application.Dto_s.CourtDto_s;
using Application.Dto_s.ManagementDto_s;
using Application.Dto_s.User;
using Application.Interfaces.ManagementService;
using Application.Repositories;
using Application.Repositories.Auth;
using AutoMapper;
using Domain.Entites;
using Domain.Entites.Permissions;
using Domain.Enums;
using Infrastrcuture.Auth;
using Infrastrcuture.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services.ManagementService
{
    public class ManagementService(IUnitOfWork _unitOfWork , IAuthRepository _authRepository , IMapper _mapper , ApplicationDbContext _context , UserManager<ApplicationUser> _userManager) : IManagementService
    {
        public async Task<AddValidation> AddUserAsync(UserAddDto userAddDto)
        {
            return await _authRepository.AddUserAsync(userAddDto);
        }

        public async Task<AddValidation> CourtAddAsync(CourtAddDto courtAddDto)
        {
            var courtGrade = await _unitOfWork.CourtGradeRepository.GetByIdAsync(courtAddDto.CourtGradeId);
            
            if (courtGrade is null)
            {
                return AddValidation.Error; 
            }

            var existingCourtsWithNameAr = await _unitOfWork.CourtRepository.GetByPropertyAsync("nameAR", courtAddDto.NameAr);
            
            if (existingCourtsWithNameAr is not null && existingCourtsWithNameAr.Any())
            {
                return AddValidation.AlreadyExist; 
            }

            if (!string.IsNullOrEmpty(courtAddDto.NameEn))
            {
                var existingCourtsWithNameEn = await _unitOfWork.CourtRepository.GetByPropertyAsync("nameEN", courtAddDto.NameEn);
                
                if (existingCourtsWithNameEn is not null && existingCourtsWithNameEn.Any())
                {
                    return AddValidation.AlreadyExist; 
                }
            }

            var courtEntity = _mapper.Map<Court>(courtAddDto);
            
            courtEntity.id = Guid.NewGuid();
            courtEntity.createdAt = DateTime.UtcNow;
            courtEntity.isDeleted = false;
            courtEntity.versionNo = 1;
            
            await _unitOfWork.CourtRepository.AddAsync(courtEntity);
            
            if (await _unitOfWork.SaveChangesAsync() > 0)
            {
                return AddValidation.Added;
            }

            return AddValidation.Error;
        }

        public async Task<DeleteAndUpdateValidatation> DeleteUserAsync(string userId, DeleteDto delete)
        {
            return await _authRepository.DeleteUserAsync(userId, delete);
        }

        public async Task<PermissionAddValidation> AddPermissionAsync(PermissionDto permission)
        {
            var PermissionEntity = _mapper.Map<Permission>(permission);
            var exisistPermission = await _unitOfWork.PermissionRepository.GetByPropertyAsync("Name" , permission.Name);

            if (exisistPermission is null || exisistPermission.Count() == 0)
            {
                await _unitOfWork.PermissionRepository.AddAsync(PermissionEntity);
                
                if(await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return PermissionAddValidation.Added;
                }

            }

            if (exisistPermission is not null || exisistPermission.Count() > 0)
            {
                return PermissionAddValidation.AlreadyExist;
            }

            return PermissionAddValidation.Error;

        }

        public async Task<AssignValdiation> AssignRoleToPermissionAsync(PermissionAssignmentDto permissionAssignment)
        {
            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(permissionAssignment.permissionId);
            var role = await _authRepository.GetRoleByIdAsync(permissionAssignment.assignedId);

            if (permission is null)
            {
                return AssignValdiation.PermissionDoesnnotExtits;
            }


            if (role is null)
            {
                return AssignValdiation.AssigedEntityDoesnotExist;
            }

            var isAssigned = await _unitOfWork.RolePermissionRepository.GetByPropertyAsync("RoleId"
                , permissionAssignment.assignedId);

            if (isAssigned is null || isAssigned.Count() == 0)
            {
                var assignmentEntity = _mapper.Map<RolePermission>(permissionAssignment);
                await _unitOfWork.RolePermissionRepository.AddAsync(assignmentEntity);

                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return AssignValdiation.Done;
                }

                return AssignValdiation.Error;
            }


            return AssignValdiation.AlreadyAssigned;

        }

        public async Task<AssignValdiation> AssignUserToPermissionAsync(PermissionAssignmentDto permissionAssignment)
        {
            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(permissionAssignment.permissionId);
            var role = await _authRepository.GetByIdAsync(permissionAssignment.assignedId);

            if (permission is null)
            {
                return AssignValdiation.PermissionDoesnnotExtits;
            }


            if (role is null)
            {
                return AssignValdiation.AssigedEntityDoesnotExist;
            }

            var isAssigned = await _unitOfWork.UserPermissionRepository.GetManyByPropertiesAsync(new Dictionary<string, object>
                                                                                            {
                                                                                                { "PermissionId", permissionAssignment.permissionId },
                                                                                                { "UserId", permissionAssignment.assignedId },
                                                                                                                    });

            if (isAssigned is null || isAssigned.Count() == 0)
            {
                var assignmentEntity = _mapper.Map<UserPermission>(permissionAssignment);
                await _unitOfWork.UserPermissionRepository.AddAsync(assignmentEntity);

                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return AssignValdiation.Done;
                }

                return AssignValdiation.Error;
            }


            return AssignValdiation.AlreadyAssigned;
        }

        public async Task<DeleteAndUpdateValidatation> DeletePermissionAsync(Guid permissionId, DeleteDto delete)
        {
            var permissionEntity = await _unitOfWork.PermissionRepository.GetByIdAsync(permissionId);
            var permissionRoleAssignmentEntity = await _unitOfWork.RolePermissionRepository.GetByPropertyAsync("PermissionId" , permissionId);
            var permissionUserAssignmentEntity = await _unitOfWork.UserPermissionRepository.GetByPropertyAsync("PermissionId" , permissionId);

            if (permissionEntity is not null)
            {
                permissionEntity.isDeleted = true;
                permissionEntity.deletionReason = delete.DeletionReason;
                permissionEntity.deletedAt = delete.DeletedAt;
                permissionEntity.deletedBy = delete.DeletedBy;


                if (permissionRoleAssignmentEntity.Count() > 0)
                {
                    
                    foreach (var roleAssignment in permissionRoleAssignmentEntity)
                    {
                        roleAssignment.isDeleted = true;
                        roleAssignment.deletionReason = delete.DeletionReason;
                        roleAssignment.deletedAt = delete.DeletedAt;
                        roleAssignment.deletedBy = delete.DeletedBy;

                    }

                    _unitOfWork.RolePermissionRepository.UpdateRange(permissionRoleAssignmentEntity);

                }

                if (permissionUserAssignmentEntity.Count() > 0)
                {

                    foreach (var userAssignment in permissionUserAssignmentEntity)
                    {
                        userAssignment.isDeleted = true;
                        userAssignment.deletionReason = delete.DeletionReason;
                        userAssignment.deletedAt = delete.DeletedAt;
                        userAssignment.deletedBy = delete.DeletedBy;

                    }

                    _unitOfWork.UserPermissionRepository.UpdateRange(permissionUserAssignmentEntity);


                }

                _unitOfWork.PermissionRepository.Update(permissionEntity);

                if (await  _unitOfWork.SaveChangesAsync() > 0)
                {
                    return DeleteAndUpdateValidatation.Done;
                }
                
                return DeleteAndUpdateValidatation.DoesnotExist;


            }

            return DeleteAndUpdateValidatation.Error;
        }

        public Task<PagedResult<RolePermissionAssignmentReadDto>> GetAllAssignedRolesToPermissionAsync(Guid permissionId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();

        }

        public Task<PagedResult<PermissionUserAssignmentReadDto>> GetAllAssignedUsersToPermissionAsync(Guid permissionId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();

        }

        public async Task<PagedResult<PermissionPrimaryDataReadDto>> GetAllPermissionsAsync(int pageNumber, int pageSize)
        {
            var permissions = await _unitOfWork.PermissionRepository.GetAllAsync(pageNumber, pageSize , true);
            var mappedData = _mapper.Map<IEnumerable<PermissionPrimaryDataReadDto>>(permissions.Data);

            var returnedData = new PagedResult<PermissionPrimaryDataReadDto>
            {
                Data = mappedData,
                PageNumber = permissions.PageNumber,
                PageSize = permissions.PageSize,
                TotalRecords = permissions.TotalRecords
            };

            return returnedData;

        }

        public async Task<PermissionPrimaryDataReadDto?> GetPermissionByIdAsync(Guid permissionId)
        {
            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(
                permissionId,
                true);
         
            if (permission == null)
            {
                return null;
            }

            var mappedData = _mapper.Map<PermissionPrimaryDataReadDto>(permission);
            return mappedData;
        }

        public async Task<PagedResult<PermissionPrimaryDataReadDto>> GetUserPermissionsAsync(string userId, int pageNumber, int pageSize)
        {
            var userPermissions = await _unitOfWork.UserPermissionRepository.GetByPropertyAsync("UserId", userId);

            var activeUserPermissions = userPermissions.Where(up => !up.isDeleted).ToList();

            if (activeUserPermissions.Count == 0)
            {
                return new PagedResult<PermissionPrimaryDataReadDto>
                {
                    Data = Enumerable.Empty<PermissionPrimaryDataReadDto>(),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = 0
                };
            }

            var permissionIds = activeUserPermissions.Select(up => up.PermissionId).Distinct().ToList();

            int totalRecords = permissionIds.Count;

            var paginatedPermissionIds = permissionIds
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var permissions = new List<Permission>();
            foreach (var permissionId in paginatedPermissionIds)
            {
                var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(
                    permissionId, 
                    true, 
                    query => query.Include(p => p.UserPermissions).Include(p => p.RolePermissions));
                if (permission != null)
                {
                    permissions.Add(permission);
                }
            }

            var mappedData = _mapper.Map<IEnumerable<PermissionPrimaryDataReadDto>>(permissions);

            return new PagedResult<PermissionPrimaryDataReadDto>
            {
                Data = mappedData,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };
        }

        public async Task<PagedResult<UserReadDto>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            var baseQuery = _context.Users
                .Where(u => !u.isDeleted)
                .AsNoTracking();

            int totalRecords = await baseQuery.CountAsync();

            var users = await baseQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var userIds = users.Select(u => u.Id).ToList();

            var userRolesDict = await _context.UserRoles
                .Where(ur => userIds.Contains(ur.UserId))
                .Join(_context.Roles,
                    ur => ur.RoleId,
                    r => r.Id,
                    (ur, r) => new { ur.UserId, RoleName = r.Name })
                .GroupBy(x => x.UserId)
                .ToDictionaryAsync(g => g.Key, g => g.First().RoleName);

            var userDtos = users.Select(user =>
            {
                var roleName = userRolesDict.TryGetValue(user.Id, out var role) ? role : null;
                
                var mappedRoleName = roleName switch
                {
                    "Admin" => "مدير",
                    "Lawyer" => "محامي",
                    "Registration Officer" => "موظف تسجيل",
                    _ => "غير متاح"
                };

                var isActiveText = user.isActive ? "نشط" : "غير نشط";

                return new UserReadDto
                {
                    Id = user.Id,
                    DisplayName = user.displayName ?? string.Empty,
                    IsActive = isActiveText,
                    CreatedAt = user.CreatedAt.ToString("yyyy-MM-dd"),
                    UserName = user.UserName ?? string.Empty,
                    Email = user.Email ?? string.Empty,
                    Role = mappedRoleName
                };
            }).ToList();

            var returnedData = new PagedResult<UserReadDto>
            {
                Data = userDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };

            return returnedData;
        }

        public async Task<DeleteAndUpdateValidatation> GrantPermissionFromRoleAsync(Guid permissionId, string roleId, DeleteDto delete)
        {
            var premissions = await _unitOfWork.RolePermissionRepository.GetManyByPropertiesAsync(new Dictionary<string, object>
                                                                                            {
                                                                                                { "PermissionId", permissionId },
                                                                                                { "RoleId", roleId },
                                                                                                                    });

            if (premissions.Count() > 0)
            {
                foreach (var premission in premissions)
                {
                    premission.isDeleted = true;
                    premission.deletionReason = delete.DeletionReason;
                    premission.deletedAt = delete.DeletedAt;
                    premission.deletedBy = delete.DeletedBy;
                }

                _unitOfWork.RolePermissionRepository.UpdateRange(premissions);

                if(await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return DeleteAndUpdateValidatation.Done;
                }

                return DeleteAndUpdateValidatation.Error;
            }
                return DeleteAndUpdateValidatation.DoesnotExist;

          }

        public async Task<DeleteAndUpdateValidatation> GrantPermissionFromUserAsync(Guid permissionId, string userId, DeleteDto delete)
        {
            var premission = await _unitOfWork.UserPermissionRepository.GetManyByPropertiesAsync(new Dictionary<string, object>
                                                                                            {
                                                                                                { "PermissionId", permissionId },
                                                                                                { "UserId", userId },
                                                                                                                    });

            if(premission.Count() > 0)
            {
                var userPermission = premission.FirstOrDefault();

                userPermission.isDeleted = true;
                userPermission.deletionReason = delete.DeletionReason;
                userPermission.deletedAt = delete.DeletedAt;
                userPermission.deletedBy = delete.DeletedBy;
                _unitOfWork.UserPermissionRepository.Update(userPermission);

                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return DeleteAndUpdateValidatation.Done;
                }
                return DeleteAndUpdateValidatation.Error;

            }


        
            return DeleteAndUpdateValidatation.DoesnotExist;
        }

        public async Task<DeleteAndUpdateValidatation> UpdatePermissionAsync(Guid permissionId, PermissionUpdateDto permission)
        {
            var permissionEntity = await _unitOfWork.PermissionRepository.GetByIdAsync(permissionId);

            if (permissionEntity is not null)
            {
                permissionEntity.Description = !string.IsNullOrEmpty(permission.Description) ? permission.Description : permissionEntity.Description;
                permissionEntity.Name = !string.IsNullOrEmpty(permission.Name) ? permission.Name : permissionEntity.Name;
                permissionEntity.updatedAt = permission.ModifiedAt;
                permissionEntity.updatedBy = permission.ModifiedBy;

                _unitOfWork.PermissionRepository.Update(permissionEntity);

                if(await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return DeleteAndUpdateValidatation.Done;
                }

                return DeleteAndUpdateValidatation.Error;
            }

            return DeleteAndUpdateValidatation.DoesnotExist;
        }

        public async Task<IEnumerable<RoleReadDto>> GetRolesForSlideMenuAsync()
        {
            return await _authRepository.GetAllRolesAsync();
        }

        public async Task<IEnumerable<CaseDropDownMenuGetDto>> GetPermissionsForDropDownMenuAsync()
        {
            var permissions = await _unitOfWork.PermissionRepository.GetAllAsync(1, 10000, true);
            
            var permissionDtos = permissions.Data.Select(permission => new CaseDropDownMenuGetDto
            {
                Id = permission.id,
                Name = permission.Name
            }).ToList();

            return permissionDtos;
        }

        public async Task<IEnumerable<CaseDropDownMenuGetDto>> GetCourtGradesForDropDownMenuAsync()
        {
            var courtGrades = await _unitOfWork.CourtGradeRepository.GetAllAsync(1, 10000, true);
            
            var courtGradeDtos = courtGrades.Data.Select(courtGrade => new CaseDropDownMenuGetDto
            {
                Id = courtGrade.id,
                Name = courtGrade.nameAR
            }).ToList();

            return courtGradeDtos;
        }

        public async Task<PagedResult<CourtPrimaryDataReadDto>> GetAllCourtsPrimaryDataAsync(int pageNumber, int pageSize)
        {
            var courts = await _unitOfWork.CourtRepository.GetAllAsync(pageNumber, pageSize, true , 
                c => c.Include(c => c.courtGrade));

            var mappedData = _mapper.Map<IEnumerable<CourtPrimaryDataReadDto>>(courts.Data);

            var returnedData = new PagedResult<CourtPrimaryDataReadDto>
            {
                Data = mappedData,
                PageNumber = courts.PageNumber,
                PageSize = courts.PageSize,
                TotalRecords = courts.TotalRecords
            };

            return returnedData;
        }

        public async Task<CourtFullDataReadDto> GetAllCourtFullDataAsync(Guid CourtId)
        {
            var result = await _unitOfWork.CourtRepository.GetByIdAsync(CourtId, true,
                                    c => c.Include(c => c.courtGrade));

            if (result is not null)
            {
                var mappedData = _mapper.Map<CourtFullDataReadDto>(result);
                return mappedData;
            }

            return new CourtFullDataReadDto();
        }

        public async Task<PagedResult<CaseReAssignmentRequestGetDto>> GetCaseReAssignmentRequests(int pageNumber , int pageSize)
        {
            var requests = await _unitOfWork.CaseReAssignmentRequestRepository.GetAllAsync(pageNumber , pageSize , true);

            var dtos = new List<CaseReAssignmentRequestGetDto>(); 

            foreach (var request in requests.Data)
            {
                var currentAssignee = await _authRepository.GetByIdAsync(request.AssigneeId);
                var currentCaseNumber = await _unitOfWork.CaseRepository.GetByIdAsync(request.CaseId , true);
                
                var dto = new CaseReAssignmentRequestGetDto
                {
                    Status = request.RequestStatus,
                    RequestSender = request.createdBy,
                    CaseId = request.CaseId,
                    RequestId = request.id,
                    RequestedAssignee = currentAssignee.DisplayName,
                    CaseNumber = currentCaseNumber.caseNumber
                };
                dtos.Add(dto);  
            }
            


            var returnedData = new PagedResult<CaseReAssignmentRequestGetDto>
            {
                Data = dtos,
                PageNumber = requests.PageNumber,
                PageSize = requests.PageSize,
                TotalRecords = requests.TotalRecords
            };

            return returnedData;

        }
    }
}
