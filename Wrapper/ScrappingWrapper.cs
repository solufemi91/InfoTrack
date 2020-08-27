using InfoTrack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoTrack.Wrapper
{
    public class ScrappingWrapper : IScrappingWrapper
    {
        private readonly IGoogleSearchResultsRepository _googleSearchResultsRepository;
        

        public ScrappingWrapper(IGoogleSearchResultsRepository googleSearchResultsRepository)
        {
            _googleSearchResultsRepository = googleSearchResultsRepository;
        }

        public string GetOrderingPositions(string keywords, string url)
        {
            var editedString = StringBuilder(keywords);
            var results = _googleSearchResultsRepository.GetSearchResultsHtml();

            return "1,2,3,4,5";
        }

        private string StringBuilder(string keywords)
        {
            return "land+registry+search";
        }

        private string ScrapeGoogleLinkTags()
        {
            return "";
        }

        private string FilterTargetedUrls()
        {
            return "";
        }

        private string CreateOrderedPositionList()
        {
            return "";
        }
    }
}