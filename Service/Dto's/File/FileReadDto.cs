using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.File
{
    public class FileReadDto
    {
        public string Name { get; set; } = string.Empty;
        public byte[] data { get; set; }
    }
}
