using Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(IGetCountriesService _getCountriesService) : ControllerBase
    {
        [HttpGet("Get-All-Countries")]
        public IActionResult GetAllCountries()
        {
            var result = _getCountriesService.GetAllCountries();
            return Ok(result);
        }

    }
}
