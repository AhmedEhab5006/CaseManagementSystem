using Application.ApplicationModels;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Commons
{
    public interface IRefernceDataRepostiory
    {
        Task<IEnumerable<RefernceDataModel>> GetCrimesAsync();
        Task<RefernceDataModel?> GetByIdAsync(Guid? Id);
    }
}
