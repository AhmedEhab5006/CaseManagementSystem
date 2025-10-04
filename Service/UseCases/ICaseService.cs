using Application.Dto_s.CaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface ICaseService
    {
        Task<bool> AddCasePrimaryData(CaseAddDto caseAddDto);
    }
}
