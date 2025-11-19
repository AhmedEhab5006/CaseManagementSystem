using Application.Dto_s.File;
using Application.Interfaces;
using Application.Interfaces.FileServices;
using Application.Repositories;
using Domain.Entites;
using Domain.Entites.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services.FileServices
{
    public class FileService(IFTPCilentService _fTPCilentService 
        , IFileEncryptionService _fileEncryptionService , IUnitOfWork _unitOfWork , ICacheService _cacheService) : IFileService
    {
        public async Task<byte[]> DownloadSecureFileAsync(FileEntity file)
        {
            using var encryptedStream = await _fTPCilentService.DownloadFileAsync(file.RemotePath);
            using var ms = new MemoryStream();
            await encryptedStream.CopyToAsync(ms);

            var decryptedBytes = await _fileEncryptionService.DecryptAsync(ms.ToArray(), file);
            return decryptedBytes;
        }

        public async Task<FileReadFromDatabaseDto?> GetFileEntityFromDatabase(Guid fileId)
        {
            var file = await _unitOfWork.FileRepository.GetByIdAsync(fileId, true);

            if (file is not null)
            {
                return new FileReadFromDatabaseDto
                {
                    Size = file.Size,
                    StorageProvider = file.StorageProvider,
                    ContentType = file.ContentType,
                    FileName = file.FileName,
                    Hash = file.Hash,
                    HashAlg = file.HashAlg,
                    KeyRef = file.KeyRef,
                    Nonce = file.Nonce,
                    RemotePath = file.RemotePath,
                    Tag = file.Tag,
                    WrappedDek = file.WrappedDek,
                };
            }

            return null;
        }

        public async Task<FileEntity> UploadSecureFileAsync(IFormFile file , string creator)
        {
            var remotePath = "/";
            
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            using var stream = file.OpenReadStream();
            var encryptedResult = await _fileEncryptionService.EncryptAsync(stream);

            var metadata = new FileEntity
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                Size = file.Length,
                Hash = encryptedResult.Hash,
                Nonce = encryptedResult.Nonce,
                Tag = encryptedResult.Tag,
                KeyRef = encryptedResult.KeyRef,
                WrappedDek = encryptedResult.WrappedDek,
                StorageProvider = "FTP",
                RemotePath = remotePath + file.FileName,
                createdAt = DateTime.UtcNow,
                versionNo = 1,
                createdBy = creator,
            };



            await _unitOfWork.FileRepository.AddAsync(metadata);
            await _unitOfWork.SaveChangesAsync();

            using var encryptedStream = new MemoryStream(encryptedResult.CipherData);
            bool success = await _fTPCilentService.UploadFileAsync(remotePath, encryptedStream, file.FileName);

            if (!success)
                throw new IOException("Failed to upload encrypted file to FTP");

            return metadata;
        }
    }
}

