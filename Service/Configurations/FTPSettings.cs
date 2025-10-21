using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations
{
    public class FTPSettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 21;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string EncryptionMode { get; set; } = "Explicit"; 
        public string DataConnectionType { get; set; } = "AutoPassive"; 
        public string RootPath { get; set; } = "/";
    }
}
