using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace InfoTrack.Repository
{
    public class GoogleSearchResultsRepository : IGoogleSearchResultsRepository
    {

        public string GetSearchResultsHtml(string keywords = "land+registry+search", string number = "100")
        {
            var client = new HttpClient();
        
            //var query = "land+registry+search";

            //var number = 100;

            return client.GetStringAsync($"https://www.google.co.uk/search?num={number}&q={keywords}").Result;
        }

    }
}