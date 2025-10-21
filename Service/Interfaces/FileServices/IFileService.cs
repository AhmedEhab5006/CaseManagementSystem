using Application.Dto_s.File;
using Domain.Entites.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.FileServices
{
    public interface IFileService
    {
        Task<FileEntity> UploadSecureFileAsync(IFormFile file , string creator);
        Task<byte[]> DownloadSecureFileAsync(FileEntity file);
        Task<FileReadFromDatabaseDto?> GetFileEntityFromDatabase(Guid fileId);
    }
}
