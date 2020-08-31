using FluentAssertions;
using InfoTrack;
using InfoTrack.Repository;
using InfoTrack.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Moq;
using Match = System.Text.RegularExpressions.Match;
using System.Linq;

namespace InfoTrackTests
{
    [TestClass]
    public class ScrappingWrapperTests
    {
        private Mock<IGoogleSearchResultsRepository> _googleSearchResultsRepositoryMock;
        private ScrappingWrapper _sut;
        private string _targetedUrl;
        private Mock<IAppSettings> _appSettingsMock;

        [TestInitialize]
        public void Setup()
        {
            _googleSearchResultsRepositoryMock = new Mock<IGoogleSearchResultsRepository>();
            _appSettingsMock = new Mock<IAppSettings>();
            _sut = new ScrappingWrapper(_appSettingsMock.Object, _googleSearchResultsRepositoryMock.Object);
            _targetedUrl = "www.infotrack.co.uk";
            SetupAppSettingsMock();
        }


        [TestMethod]
        public void ScrappingWrapper_StringBuilder_WhenKeywordsWithSpaceIsGiven_NewStringWithSpacesReplacedByPlusSignIsReturned()
        {
            var keyWords = "land search registry";
            var expectedResult = "land+search+registry";

            var result = _sut.StringBuilder(keyWords);

            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ScrappingWrapper_ScrapeGoogleTagsLink_WhenTheHtmlContainsTheDesiredPattern_ThenTheResultsCountShouldBeGreaterThanZero()
        {
            var googleResults = HtmlBuilder();

            var results = _sut.ScrapeGoogleLinkTags(googleResults);

            results.Count().Should().BeGreaterThan(0);
        }


        [TestMethod]
        public void ScrappingWrapper_FilterTargetedUrls_WhenThereIsMultipleUrlsAndATargetUrlIsGiven_ThenOnlyThatUrlIsReturned()
        {
            var scrappedGoogleTags = GetScrapedGoogleLinkTagsData();

            var result = _sut.FilterTargetedUrls(scrappedGoogleTags, _targetedUrl);

            result.Count().Should().Be(2);
            result.All(x => x.Html.Contains(_targetedUrl)).Should().BeTrue();

        }

        [TestMethod]
        public void ScrappingWrapper_CreateOrderedPositionList_WhenAListOfGoogleLinksIsGiven_ThenTheCorrectStringOfIntegersIsReturned()
        {
            var scrappedGoogleTags = GetScrapedGoogleLinkTagsData();
            var filteredTargetedUrls = _sut.FilterTargetedUrls(scrappedGoogleTags, _targetedUrl);

            var result = _sut.CreateOrderedPositionList(filteredTargetedUrls);

            result.Should().Be("2,3");

        }

        private void SetupAppSettingsMock()
        {
            var htmlToMatch = @"<div class=""kCrYT""><a href(.+?)<h3";

            _appSettingsMock.Setup(x => x.HtmlToMatch).Returns(htmlToMatch);
        }

        private IEnumerable<Match> GetScrapedGoogleLinkTagsData()
        {
            var googleResults = HtmlBuilder();
            return _sut.ScrapeGoogleLinkTags(googleResults);
        }

        private string HtmlBuilder()
        {
            var html = @"<!DOCTYPE html><head></head><body><div><div class=""kCrYT""><a href=""/url?q=https://www.leeds.gov.uk/planning/local-land-charges&amp;sa=U&amp;ved=2ahUKEwjUyrK558LrAhXJTxUIHbL6A9gQFjAiegQITxAB&amp;usg=AOvVaw3HS2AZNYJaQK0CxtUbOSS3""><h3 
                        class=""zBAuLc""><div class=""BNeawe vvjwJb AP7Wnd"">Local Land Charges and searches - Leeds City Council</div></div></h3><div><div class=""kCrYT""><a href=""/url?q=https://www.infotrack.co.uk""><h3
                        <div class=""kCrYT""><a href=""/url?q=https://www.infotrack.co.uk""><h3 
                        class=""zBAuLc""</div><body><html>";
            return html;
        }

    }
}
