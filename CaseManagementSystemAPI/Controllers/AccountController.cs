using Application.Commands.AccountCommands;
using Application.Dto_s.AccountDto_s;
using Application.Queries.AccountQueries;
using Application.UseCases.Auth;
using CaseManagementSystemAPI.ResponseHelpers.AccountControllerResponseHelper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController(IMediator _mediator , IAuthService _authService) : ControllerBase
    {
        [HttpGet("Get-Account-Info")]
        public async Task <IActionResult> GetAccountInfo()
        {
            var id = _authService.GetLoggedId();
            var query = new GetAccountDataQuery(id);
            var result = await _mediator.Send(query);
            return GetAccountDataResponseHelper.Map(result);

        }

        [HttpPut("Edit-Account-Info")]
        public async Task<IActionResult> EditAccountInfo(AccountEditDto accountEditDto)
        {
            var id = _authService.GetLoggedId();
            accountEditDto.username = _authService.GetLoggedUserName();
            var command = new EditInfoCommand(accountEditDto, id);
            var result = await _mediator.Send(command);
            return EditAccountInfoResponseHelper.Map(result);
        }

    }
}
