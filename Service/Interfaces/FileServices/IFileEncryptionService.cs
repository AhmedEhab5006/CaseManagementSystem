using Application.Commons;
using Domain.Entites.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.FileServices
{
    public interface IFileEncryptionService
    {
        Task<EncryptedFileResult> EncryptAsync(Stream plainFile);
        Task<byte[]> DecryptAsync(byte[] cipherData, FileEntity file);
    }
}
