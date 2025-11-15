using Application.Repositories.CaseRepositories;
using Application.Repositories.CourtRepositories;
using Application.Repositories.FileRepoisitories;
using Application.Repositories.ManagementRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUnitOfWork
    {

        #region Case Repositories
        public ICaseRepository CaseRepository { get;}
        public ICaseAssignmentRepository CaseAssignmentRepository { get;}
        public ICaseReAssignmentRequestRepository CaseReAssignmentRequestRepository { get;}
        public ICaseEventRepository CaseEventRepository { get;}
        public ILitigantRepository LitigantRepository { get;}
        public ICaseLitigantRepository CaseLitigantRepository { get;}
        public ICaseLitigantRoleRepository CaseLitigantRoleRepository { get;}
        public ICaseTopicRepository CaseTopicRepository { get;}
        public ICaseTypeRepository CaseTypeRepository { get;}
        public ICaseDocumentRepository CaseDocumentRepository { get; }
        public ICaseDocTypeRepository CaseDocTypeRepository { get; }
        public IFileRepository FileRepository { get;}
        public ILitigantCrimeRepository LitigantCrimeRepository { get;}
        #endregion

        #region Court Repos

        public ICourtRepository CourtRepository { get; }
        public ICourtGradeRepository CourtGradeRepository { get; }


        #endregion

        #region Managment Repos

        public IUserPermissionRepository UserPermissionRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        public IRolePermissionRepository RolePermissionRepository { get; }


        #endregion

        #region Save Changes
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        #endregion
    }
}
