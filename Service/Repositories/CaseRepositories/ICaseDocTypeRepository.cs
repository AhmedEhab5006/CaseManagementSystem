using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.CaseRepositories
{
    public interface ICaseDocTypeRepository : IGenericRepository<DocType>
    {
        public IQueryable<DocType> GetAll();

    }
}
