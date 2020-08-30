using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace InfoTrack.Repository
{
    public class GoogleSearchResultsRepository : IGoogleSearchResultsRepository
    {

        public async Task<string> GetSearchResultsHtmlAsync(string keywords)
        {
            var googleUrl = WebConfigurationManager.AppSettings["GoogleUrl"];
            var client = new HttpClient();
        
            return await client.GetStringAsync($"{googleUrl}num={100}&q={keywords}");
        }

    }
}