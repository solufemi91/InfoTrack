using InfoTrack.Models;
using InfoTrack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace InfoTrack.Wrapper
{
    public class ScrappingWrapper : IScrappingWrapper
    {
        private readonly IGoogleSearchResultsRepository _googleSearchResultsRepository;
        

        public ScrappingWrapper(IGoogleSearchResultsRepository googleSearchResultsRepository)
        {
            _googleSearchResultsRepository = googleSearchResultsRepository;
        }

        public async Task<string> GetOrderingPositionsAsync(string keywords, string url)
        {
            var editedString = StringBuilder(keywords);
            var googleResults = await _googleSearchResultsRepository.GetSearchResultsHtmlAsync(editedString);
            var scrappedGoogleLinkTags = ScrapeGoogleLinkTags(googleResults);
            var targetedUrlList = FilterTargetedUrls(scrappedGoogleLinkTags, url);


            var orderedPositionList = CreateOrderedPositionList(targetedUrlList);

            return orderedPositionList == string.Empty ? "No Results found in the top 100" : orderedPositionList;
        }

        public string StringBuilder(string keywords)
        {
            var result = Regex.Replace(keywords, "\\s+", "+");
            return result;
        }

        public IEnumerable<Match> ScrapeGoogleLinkTags(string googleResults)
        {
            var htmlToMatch = WebConfigurationManager.AppSettings["HtmlToMatch"];

            var regexMatches = Regex.Matches(googleResults, htmlToMatch);
            return regexMatches.Cast<Match>();
        }

        public IEnumerable<GoogleLinks> FilterTargetedUrls(IEnumerable<Match> scrappedGoogleLinkTags, string url)
        {
            return scrappedGoogleLinkTags.Select((m, i) => new GoogleLinks { Html = m?.Value, Index = i })
              .Where(x => x.Html.Contains(url));
        }

        public string CreateOrderedPositionList(IEnumerable<GoogleLinks> googleLinks)
        {
            var arrayOfOrderPositions = googleLinks.Select(x => x.Index + 1);

            return string.Join(",", arrayOfOrderPositions);
        }
    }
}