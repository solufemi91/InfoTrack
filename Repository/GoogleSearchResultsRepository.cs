using System;
using System.Net.Http;
using System.Web.Configuration;

namespace InfoTrack.Repository
{
    public class GoogleSearchResultsRepository : IGoogleSearchResultsRepository
    {

        public string GetSearchResultsHtml(string keywords)
        {
            var googleUrl = WebConfigurationManager.AppSettings["GoogleUrl"];
            var client = new HttpClient();
        
            return client.GetStringAsync($"{googleUrl}num={100}&q={keywords}").Result;
        }

    }
}