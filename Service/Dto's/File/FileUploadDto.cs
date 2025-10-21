using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.File
{
    public class FileUploadDto
    {
        public string createdBy { get; set; } = string.Empty;
        public IFormFile File { get; set; }
    }
}
