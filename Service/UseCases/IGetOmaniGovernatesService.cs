using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public interface IGetOmaniGovernatesService
    {
        public IEnumerable<string> GetAllWilayats(string governorate);
        public IEnumerable<string> GetAllGovernates();
        public IEnumerable<string> GetAllVillages(string wilayat);
    }
}
