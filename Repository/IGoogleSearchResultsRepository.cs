using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.Repository
{
    public interface IGoogleSearchResultsRepository
    {
        Task<string> GetSearchResultsHtmlAsync(string keywords);
    }
}
