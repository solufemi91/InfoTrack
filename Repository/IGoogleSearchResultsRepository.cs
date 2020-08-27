using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Repository
{
    public interface IGoogleSearchResultsRepository
    {
        string GetSearchResultsHtml(string keywords = "land+registry+search", string number = "100");
    }
}
