using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Security.Cryptography;
using Application.Commands.FileCommands;
using Application.Interfaces.FileServices;
using Application.Repositories.FileRepoisitories;

namespace Application.Handlers.FileHandlers
{
    public class UploadFileCommandHandler(IFileService _fileService) : IRequestHandler<UploadFileCommand, List<Guid>>
    {
        public async Task<List<Guid>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var uploadedFileIds = new List<Guid>();


                var metadata = await _fileService.UploadSecureFileAsync(request.FileUploadDto.File , request.FileUploadDto.createdBy);
                uploadedFileIds.Add(metadata.id);
            

            return uploadedFileIds;
        }
    }
    }

