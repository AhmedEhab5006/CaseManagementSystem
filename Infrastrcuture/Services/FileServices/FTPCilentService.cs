using Application.Configurations;
using Application.Interfaces.FileServices;
using FluentFTP;
using FluentFTP.Client;
using FluentFTP.Client.BaseClient;
using FluentFTP.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services.FileServices
{
    public class FTPCilentService : IFTPCilentService
    {


        private readonly string _host;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;
        private readonly IConfiguration _config;
        private readonly string _rootPath;


        public FTPCilentService(IConfiguration config)
        {
            _config = config;
            _rootPath = _config["FileStorage:Ftps:RootPath"] ?? "/";


        }

        private async Task<AsyncFtpClient> CreateClientAsync()
        {
            var section = _config.GetSection("FileStorage:Ftps");

            var host = section["Host"];
            var username = section["Username"];
            var password = section["Password"];
            var port = int.Parse(section["Port"] ?? "21");

            var encryptionMode = Enum.TryParse<FtpEncryptionMode>(
                section["EncryptionMode"],
                out var parsedEncryptionMode
            ) ? parsedEncryptionMode : FtpEncryptionMode.Explicit;

            var dataConnectionType = Enum.TryParse<FtpDataConnectionType>(
                section["DataConnectionType"],
                out var parsedDataType
            ) ? parsedDataType : FtpDataConnectionType.AutoPassive;


            var client = new AsyncFtpClient(host, new NetworkCredential(username, password) , port);
            
            client.Config.EncryptionMode = encryptionMode;
            client.Config.DataConnectionType = dataConnectionType;
            client.Config.ValidateAnyCertificate = true;
            client.Config.ConnectTimeout = 15000; 
            client.Config.ReadTimeout = 30000;
            client.Config.DataConnectionConnectTimeout = 15000;
            client.Config.DataConnectionReadTimeout = 30000;
            
            await client.Connect();

            return client;
        }
        public async Task DeleteFileAsync(string remotePath)
        {
            using var client = await CreateClientAsync();

            var fullPath = _rootPath + remotePath;
             await client.DeleteFile(fullPath);
        }

        public async Task<Stream> DownloadFileAsync(string remotePath)
        {
            using var client = await CreateClientAsync();

            var fullPath = _rootPath + remotePath;
            var memoryStream = new MemoryStream();

            var result = await client.DownloadStream(memoryStream, fullPath);
            if (result)
            {
                memoryStream.Position = 0;
                return memoryStream;
            }

            throw new IOException($"Failed to download file: {remotePath}");
        }

        public async Task<bool> FileExistsAsync(string remotePath)
        {
            using var client = await CreateClientAsync();

            var fullPath = _rootPath + remotePath;
            return await client.FileExists(fullPath);
        }

        public async Task<bool> UploadFileAsync(string remotePath, Stream fileStream, string fileName)
        {
            using var client = await CreateClientAsync();

            if (!remotePath.EndsWith("/"))
                remotePath += "/";

            // Full path on FTP server
            var fullPath = _rootPath + remotePath + fileName;

            await client.CreateDirectory(_rootPath + remotePath, true);

            var status = await client.UploadStream(fileStream, fullPath, FtpRemoteExists.Overwrite, false);

            return status.IsSuccess();
        }
    }
}
