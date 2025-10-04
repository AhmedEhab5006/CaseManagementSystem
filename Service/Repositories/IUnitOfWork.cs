using Application.Repositories.CaseRepositories;
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
        #endregion

        #region Save Changes
        Task<int> SaveChangesAsync();
        #endregion
    }
}
