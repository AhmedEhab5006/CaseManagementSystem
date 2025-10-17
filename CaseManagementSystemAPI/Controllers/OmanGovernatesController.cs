using Application.UseCases;
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
            if (string.IsNullOrWhiteSpace(governorate))
                return BadRequest("Governorate is required");

            var result = _getOmaniGovernatesService.GetAllWilayats(governorate);
            return Ok(result);
        }

        [HttpGet("villages-{wilayat}")]
        public IActionResult GetVillages(string wilayat)
        {
            if (string.IsNullOrWhiteSpace(wilayat))
                return BadRequest("Wilayat is required");

            var result = _getOmaniGovernatesService.GetAllVillages(wilayat);
            return Ok(result);
        }
    }
}
