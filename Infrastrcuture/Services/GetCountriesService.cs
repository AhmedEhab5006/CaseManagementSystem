using Application.Dto_s.CountriesReadDto;
using Application.Dto_s.OmanGovernatesDtos;
using Application.UseCases;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services
{
    public class GetCountriesService : IGetCountriesService
    {

        private readonly string _filePath;
        private List<CountriesReadDto> _cachedData;

        public GetCountriesService(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<CountriesReadDto> GetAll()
        {
            if (_cachedData != null)
                return _cachedData;

            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            _cachedData = csv.GetRecords<CountriesReadDto>().ToList();
            return _cachedData;

        }

        public IEnumerable<string> GetAllCountries()
        {
            return GetAll()
                        .Select(x => x.name)
                        .Distinct()
                        .OrderBy(x => x)
                        .ToList();


        }
    }
}
