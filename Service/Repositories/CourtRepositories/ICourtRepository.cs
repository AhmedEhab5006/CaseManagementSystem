using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Repositories.IGenericRepository;

namespace Application.Repositories.CourtRepositories
{
    public interface ICourtRepository : IGenericRepository<Court>
    {
        public IQueryable<Court> GetAll();

    }
}
