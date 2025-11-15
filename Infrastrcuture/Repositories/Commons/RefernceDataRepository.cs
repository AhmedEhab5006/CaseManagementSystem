using Application.ApplicationModels;
using Application.Repositories.Commons;
using Application.Repositories.ManagementRepos;
using Domain.Entites.Permissions;
using Domain.Enums;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.Commons
{
    public class RefernceDataRepository(ApplicationDbContext _context) : IRefernceDataRepostiory
    {
        public async Task<RefernceDataModel?> GetByIdAsync(Guid? Id)
        {
            var data = await _context.RefernecesData.FindAsync(Id);
            
            if(data is not null)
            {
                var returned = new RefernceDataModel
                {
                    id = data.id,
                    ValueAr = data.ValueAr
                };
                return returned;

            }
            return null;
        }

        public async Task<IEnumerable<RefernceDataModel>> GetCrimesAsync()
        {
            var crimes = await _context.RefernecesData
                                .Where(a=>a.Type == ReferenceDataTypes.Crime)
                                .ToListAsync();

            var returnedData = new List<RefernceDataModel>();
            
            foreach (var crime in crimes)
            {
                var dto = new RefernceDataModel
                {
                    id = crime.id,
                    ValueAr = crime.ValueAr,
                };

                returnedData.Add(dto);
            }

            return returnedData;
        }
    }
}
