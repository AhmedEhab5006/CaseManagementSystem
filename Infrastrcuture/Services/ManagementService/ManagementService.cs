using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.Dto_s.Commons;
using Application.Dto_s.ManagementDto_s;
using Application.Interfaces.ManagementService;
using Application.Repositories;
using Application.Repositories.Auth;
using AutoMapper;
using Domain.Entites.Permissions;
using Domain.Enums;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services.ManagementService
{
    public class ManagementService(IUnitOfWork _unitOfWork , IAuthRepository _authRepository , IMapper _mapper , ApplicationDbContext _context) : IManagementService
    {
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

            var isAssigned = await _unitOfWork.UserPermissionRepository.GetByPropertyAsync("UserId"
                , permissionAssignment.assignedId);

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
            var premissions = await _unitOfWork.UserPermissionRepository.GetManyByPropertiesAsync(new Dictionary<string, object>
                                                                                            {
                                                                                                { "PermissionId", permissionId },
                                                                                                { "UserId", userId },
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

                _unitOfWork.UserPermissionRepository.UpdateRange(premissions);

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
    }
}
