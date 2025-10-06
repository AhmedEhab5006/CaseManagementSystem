using Application.Repositories.CaseRepositories;
using Application.Repositories.CourtRepositories;
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
        public ICaseEventRepository CaseEventRepository { get;}
        public ILitigantRepository LitigantRepository { get;}
        public ICaseLitigantRepository CaseLitigantRepository { get;}
        public ICaseLitigantRoleRepository CaseLitigantRoleRepository { get;}
        public ICaseTopicRepository CaseTopicRepository { get;}
        public ICaseTypeRepository CaseTypeRepository { get;}
        #endregion

        #region Court Repos

        public ICourtRepository CourtRepository { get; }
        public ICourtGradeRepository CourtGradeRepository { get; }


        #endregion

        #region Save Changes
        Task<int> SaveChangesAsync();
        #endregion
    }
}
