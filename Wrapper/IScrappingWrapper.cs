using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Wrapper
{
    public interface IScrappingWrapper
    {
        string GetOrderingPositions(string keywords, string url);
    }
}
