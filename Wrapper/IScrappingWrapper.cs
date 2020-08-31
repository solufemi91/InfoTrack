using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Wrapper
{
    public interface IScrappingWrapper
    {
        Task<string> GetOrderingPositionsAsync(string keywords, string url);
    }
}
