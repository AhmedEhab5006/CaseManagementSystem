using Application.Repositories;
using Application.Repositories.CaseRepositories;
using Application.Repositories.CourtRepositories;
using Application.Repositories.FileRepoisitories;
using AutoMapper;
using Infrastrcuture.Database;
using Infrastrcuture.Repositories.CaseRepositories;
using Infrastrcuture.Repositories.CourtRepositories;
using Infrastrcuture.Repositories.File;
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
        private readonly Lazy<ICaseAssignmentRepository> _caseAssignmentRepository;
        private readonly Lazy<ICaseEventRepository> _caseEventRepository;
        private readonly Lazy<ICaseLitigantRepository> _caseLitigantRepository;
        private readonly Lazy<ICaseLitigantRoleRepository> _caseLitigantRoleRepository;
        private readonly Lazy<ICaseTopicRepository> _caseTopicRepository;
        private readonly Lazy<ICaseTypeRepository> _caseTypeRepository;
        private readonly Lazy<ILitigantRepository> _litigantRepository;
        private readonly Lazy<IFileRepository> _fileRepository;
        private readonly Lazy<ICaseDocumentRepository> _caseDocumentRepository;
        private readonly Lazy<ICaseDocTypeRepository> _caseDocTypeRepository;


        #endregion

        #region Court Repositories

        private readonly Lazy<ICourtRepository> _courtRepository;
        private readonly Lazy<ICourtGradeRepository> _courtGradeRepository;


        #endregion

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            #region Case Repositories Initialization
            
            _caseRepository = new Lazy<ICaseRepository>(() => new CaseRepository(dbContext));
            _caseAssignmentRepository = new Lazy<ICaseAssignmentRepository>(() => new CaseAssignmentRepository(dbContext , _mapper));
            _caseEventRepository = new Lazy<ICaseEventRepository>(() => new CaseEventRepository(dbContext));
            _caseLitigantRepository = new Lazy<ICaseLitigantRepository>(() => new CaseLitigantRepository(dbContext));
            _caseLitigantRoleRepository = new Lazy<ICaseLitigantRoleRepository>(() => new CaseLitigantRoleRepository(dbContext));
            _caseTopicRepository = new Lazy<ICaseTopicRepository>(() => new CaseTopicRepository(dbContext));
            _caseTypeRepository = new Lazy<ICaseTypeRepository>(() => new CaseTypeRepository(dbContext));
            _litigantRepository = new Lazy<ILitigantRepository>(() => new LitigantRepository(dbContext));
            _fileRepository = new Lazy<IFileRepository>(() => new FileRepository(dbContext));
            _caseDocumentRepository = new Lazy<ICaseDocumentRepository>(() => new CaseDocumentRepository(dbContext));
            _caseDocTypeRepository = new Lazy<ICaseDocTypeRepository>(() => new CaseDocTypeRepository(dbContext));

            #endregion

            #region Court Repositories Initialisation

            _courtRepository = new Lazy<ICourtRepository>(() => new CourtRepository(dbContext));
            _courtGradeRepository = new Lazy<ICourtGradeRepository>(() => new CourtGradeRepository(dbContext));


            #endregion

            this._dbContext = dbContext;

        }

        #region Case Repositories Instances

        public ICaseRepository CaseRepository => _caseRepository.Value;
        public ICaseAssignmentRepository CaseAssignmentRepository => _caseAssignmentRepository.Value;
        public ICaseEventRepository CaseEventRepository => _caseEventRepository.Value;
        public ICaseLitigantRepository CaseLitigantRepository => _caseLitigantRepository.Value;
        public ICaseLitigantRoleRepository CaseLitigantRoleRepository => _caseLitigantRoleRepository.Value;
        public ICaseTopicRepository CaseTopicRepository => _caseTopicRepository.Value;
        public ICaseTypeRepository CaseTypeRepository => _caseTypeRepository.Value;
        public ILitigantRepository LitigantRepository => _litigantRepository.Value;
        public IFileRepository FileRepository => _fileRepository.Value;
        public ICaseDocumentRepository CaseDocumentRepository => _caseDocumentRepository.Value;
        public ICaseDocTypeRepository CaseDocTypeRepository => _caseDocTypeRepository.Value;


        #endregion

        #region Court Repositories Instances

        public ICourtRepository CourtRepository => _courtRepository.Value;
        public ICourtGradeRepository CourtGradeRepository => _courtGradeRepository.Value;


        #endregion

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
