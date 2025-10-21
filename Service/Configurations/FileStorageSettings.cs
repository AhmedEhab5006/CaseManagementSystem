using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations
{
    public class FileStorageSettings
    {
        public string Provider { get; set; } = "FTPS"; 
        public FTPSettings Ftps { get; set; } = new();
    }
}
