using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace InfoTrack.Repository
{
    public class GoogleSearchResultsRepository : IGoogleSearchResultsRepository
    {

        public string GetSearchResultsHtml(string keywords, int number = 10)
        {
            var client = new HttpClient();
        
            return client.GetStringAsync($"https://www.google.co.uk/search?num={number}&q={keywords}").Result;
        }

    }
}