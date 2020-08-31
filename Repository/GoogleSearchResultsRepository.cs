using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace InfoTrack.Repository
{
    public class GoogleSearchResultsRepository : IGoogleSearchResultsRepository
    {
        private readonly IAppSettings _appSettings;
        public GoogleSearchResultsRepository(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public async Task<string> GetSearchResultsHtmlAsync(string keywords)
        {
            var googleUrl = _appSettings.GoogleUrl;
            var numberOfResults = _appSettings.NumberOfResults;
            var client = new HttpClient();
        
            return await client.GetStringAsync($"{googleUrl}num={numberOfResults}&q={keywords}");
        }

    }
}