using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.FileServices
{
    public interface IFTPCilentService
    {
        Task<bool> UploadFileAsync(string remotePath, Stream fileStream, string fileName);
        Task<Stream> DownloadFileAsync(string remotePath);
        Task DeleteFileAsync(string remotePath);
        Task<bool> FileExistsAsync(string remotePath);
    }
}
