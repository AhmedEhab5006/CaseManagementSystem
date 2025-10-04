using Application.Repositories;
using Application.Repositories.CaseRepositories;
using Infrastrcuture.Database;
using Infrastrcuture.Repositories.CaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Case Repositories

        private readonly Lazy<ICaseRepository> _caseRepository;


        #endregion
        
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            #region Case Repositories Initialization
            
            _caseRepository = new Lazy<ICaseRepository>(() => new CaseRepository(dbContext));
            
            #endregion

            this._dbContext = dbContext;

        }

        #region Case Repositories Instances

        public ICaseRepository CaseRepository => _caseRepository.Value;


        #endregion

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
