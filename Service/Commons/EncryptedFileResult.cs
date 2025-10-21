using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons
{
    public record EncryptedFileResult
    (
        byte[] CipherData,
        string Hash,
        byte[] Nonce,
        byte[] Tag,
        string KeyRef,
        byte[] WrappedDek
    );

}
