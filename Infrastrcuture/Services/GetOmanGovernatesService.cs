using Application.Dto_s.OmanGovernatesDtos;
using Application.UseCases;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;


namespace Infrastrcuture.Services
{
    public class GetOmanGovernatesService : IGetOmaniGovernatesService
    {

        private readonly string _filePath;
        private List<OmanGoverntatesDto> _cachedData;

        public GetOmanGovernatesService(string filePath)
        {
            _filePath = filePath;
        }

        private IEnumerable<OmanGoverntatesDto> GetAllLocations()
        {
            if (_cachedData != null)
                return _cachedData;

            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            _cachedData = csv.GetRecords<OmanGoverntatesDto>().ToList();
            return _cachedData;
        }

        public IEnumerable<string> GetAllGovernates()
        {
            return GetAllLocations()
                .Select(x => x.Governorate)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        public IEnumerable<string> GetAllWilayats(string governorate)
        {
            return GetAllLocations()
                .Where(x => x.Governorate == governorate)
                .Select(x => x.Wilayat)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        public IEnumerable<string> GetAllVillages(string wilayat)
        {
            return GetAllLocations()
                .Where(x => x.Wilayat == wilayat)
                .Select(x => x.Village)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }
    }
}
