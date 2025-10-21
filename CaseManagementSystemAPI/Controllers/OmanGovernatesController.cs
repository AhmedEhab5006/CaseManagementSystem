using Application.UseCases;
using CaseManagementSystemAPI.ResponseHelpers.OmaniGoverantesControllerResponseHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OmanGovernatesController(IGetOmaniGovernatesService _getOmaniGovernatesService) : ControllerBase
    {
        [HttpGet("Get-Governorates")]
        public IActionResult GetGovernorates()
        {
            var result = _getOmaniGovernatesService.GetAllGovernates();
            return Ok(result);
        }

        [HttpGet("wilayats-{governorate}")]
        public IActionResult GetWilayats(string governorate)
        {
            var result = _getOmaniGovernatesService.GetAllWilayats(governorate);
            return GetResponseHelper.Map(result);
        }

        [HttpGet("villages-{wilayat}")]
        public IActionResult GetVillages(string wilayat)
        {
            var result = _getOmaniGovernatesService.GetAllVillages(wilayat);
            return GetResponseHelper.Map(result);
        }
    }
}
