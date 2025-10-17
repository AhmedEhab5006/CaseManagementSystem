using Application.Dto_s.CountriesReadDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface IGetCountriesService
    {
        public IEnumerable<string> GetAllCountries();

    }
}
