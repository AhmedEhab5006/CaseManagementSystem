using Application.Commands.FileCommands;
using Application.Dto_s.File;
using Application.Interfaces.FileServices;
using Application.Queries.FileQueries;
using CaseManagementSystemAPI.ResponseHelpers.FileControllerResponseHelper;
using Domain.Entites.Files;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("Upload-File")]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadDto fileUploadDto)
        {
            var command = new UploadFileCommand(fileUploadDto);
            var uploadedFileIds = await _mediator.Send(command);
            return UploadFileResponseHelper.Map(uploadedFileIds);
         
        }


        [HttpGet("Download-File-{fileId}")]
        public async Task<IActionResult> DownloadFile(Guid fileId)
        {
            var query = new DownloadFileQuery(fileId);
            var result = await _mediator.Send(query);
            return DownloadFileResponseHelper.Map(result);
        }
    }
}
