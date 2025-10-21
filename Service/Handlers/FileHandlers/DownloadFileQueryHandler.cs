using Application.Dto_s.File;
using Application.Interfaces.FileServices;
using Application.Queries.FileQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.FileHandlers
{
    internal class DownloadFileQueryHandler(IFileService _fileService) : IRequestHandler<DownloadFileQuery, FileReadDto>
    {
        public async Task<FileReadDto> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
        {
            var fileEntity = await _fileService.GetFileEntityFromDatabase(request._fileId);

            if (fileEntity is not null)
            {
                var file = await _fileService.DownloadSecureFileAsync(new Domain.Entites.Files.FileEntity
                {
                    Size = fileEntity.Size,
                    StorageProvider = fileEntity.StorageProvider,
                    ContentType = fileEntity.ContentType,
                    FileName = fileEntity.FileName,
                    Hash = fileEntity.Hash,
                    KeyRef = fileEntity.KeyRef,
                    Nonce = fileEntity.Nonce,
                    HashAlg = fileEntity.HashAlg,
                    RemotePath = fileEntity.RemotePath,
                    Tag = fileEntity.Tag,
                    WrappedDek = fileEntity.WrappedDek,

                });


                return new FileReadDto
                {
                    data = file,
                    Name = fileEntity.FileName
                };

            }

            return null;
        }
    }
}
