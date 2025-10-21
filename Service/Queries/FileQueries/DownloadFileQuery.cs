using Application.Dto_s.File;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.FileQueries
{
    public class DownloadFileQuery : IRequest<FileReadDto>
    {
        public Guid _fileId;
        public DownloadFileQuery(Guid fileId) {
            _fileId = fileId;
        
        }
    }
}
