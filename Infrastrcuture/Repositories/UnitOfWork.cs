using Application.Repositories;
using Application.Repositories.CaseRepositories;
using Application.Repositories.CourtRepositories;
using Application.Repositories.FileRepoisitories;
using Application.Repositories.ManagementRepos;
using AutoMapper;
using Domain.Entites;
using Domain.Entites.Files;
using Domain.Entites.Permissions;
using Infrastrcuture.Database;
using Infrastrcuture.Repositories.CaseRepositories;
using Infrastrcuture.Repositories.CourtRepositories;
using Infrastrcuture.Repositories.File;
using Infrastrcuture.Repositories.ManagementRepos;
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

        #region Managment Repos

        private readonly Lazy<IRolePermissionRepository> _rolePermissionRepository;
        private readonly Lazy<IPermissionRepository> _permissionRepository;
        private readonly Lazy<IUserPermissionRepository> _userPermissionRepository;


        #endregion

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            #region Case Repositories Initialization
            
            _caseRepository = new Lazy<ICaseRepository>(() => new CaseRepository(dbContext , dbContext.Set<Case>()));
            _caseAssignmentRepository = new Lazy<ICaseAssignmentRepository>(() => new CaseAssignmentRepository(dbContext , dbContext.Set<CaseAssignment>(), _mapper ));
            _caseEventRepository = new Lazy<ICaseEventRepository>(() => new CaseEventRepository(dbContext , dbContext.Set<CaseEvent>()));
            _caseLitigantRepository = new Lazy<ICaseLitigantRepository>(() => new CaseLitigantRepository(dbContext , dbContext.Set<CaseLitigant>()));
            _caseLitigantRoleRepository = new Lazy<ICaseLitigantRoleRepository>(() => new CaseLitigantRoleRepository(dbContext , dbContext.Set<CaseLitigantRole>()));
            _caseTopicRepository = new Lazy<ICaseTopicRepository>(() => new CaseTopicRepository(dbContext , dbContext.Set<CaseTopic>()));
            _caseTypeRepository = new Lazy<ICaseTypeRepository>(() => new CaseTypeRepository(dbContext , dbContext.Set<CaseType>()));
            _litigantRepository = new Lazy<ILitigantRepository>(() => new LitigantRepository(dbContext , dbContext.Set<Litigant>()));
            _fileRepository = new Lazy<IFileRepository>(() => new FileRepository(dbContext , dbContext.Set<FileEntity>()));
            _caseDocumentRepository = new Lazy<ICaseDocumentRepository>(() => new CaseDocumentRepository(dbContext , dbContext.Set<CaseDocument>()));
            _caseDocTypeRepository = new Lazy<ICaseDocTypeRepository>(() => new CaseDocTypeRepository(dbContext , dbContext.Set<DocType>()));
           
            #endregion

            #region Court Repositories Initialisation

            _courtRepository = new Lazy<ICourtRepository>(() => new CourtRepository(dbContext , dbContext.Set<Court>()));
            _courtGradeRepository = new Lazy<ICourtGradeRepository>(() => new CourtGradeRepository(dbContext , dbContext.Set<CourtGrade>()));


            #endregion

            #region Managment Repos Init

            _rolePermissionRepository = new Lazy<IRolePermissionRepository>(() => new RolePermissionRepostiory(dbContext , dbContext.Set<RolePermission>()));
            _userPermissionRepository = new Lazy<IUserPermissionRepository>(() => new UserPermissionRepository(dbContext , dbContext.Set<UserPermission>()));
            _permissionRepository = new Lazy<IPermissionRepository>(() => new PermissionRepostiory(dbContext , dbContext.Set<Permission>()));

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

        #region Managment Repos Instances

        public IRolePermissionRepository RolePermissionRepository => _rolePermissionRepository.Value;
        public IUserPermissionRepository UserPermissionRepository => _userPermissionRepository.Value;
        public IPermissionRepository PermissionRepository => _permissionRepository.Value;


        #endregion

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
