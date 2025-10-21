using Application.Dto_s.File;
using MediatR;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FileCommands
{
    public class UploadFileCommand : IRequest<List<Guid>>
    {
            public FileUploadDto FileUploadDto { get; }

            public UploadFileCommand(FileUploadDto fileUploadDto)
            {
                FileUploadDto = fileUploadDto;
               
            }
      
    }

}
