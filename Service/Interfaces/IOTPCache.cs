using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOTPCache
    {
       public void Set(string key, string value, TimeSpan expiration);
       public string? Get(string key);
       public void Remove(string key);
    }
}
