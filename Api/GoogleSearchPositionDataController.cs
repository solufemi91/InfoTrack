using InfoTrack.Models;
using InfoTrack.Wrapper;
using System.Web.Mvc;

namespace InfoTrack.Api
{
    public class GoogleSearchPositionDataController : Controller
    {

        private readonly IScrappingWrapper _scrappingWrapper;

        public GoogleSearchPositionDataController(IScrappingWrapper scrappingWrapper)
        {
            _scrappingWrapper = scrappingWrapper;
        }

        [HttpPost]
        public string ReturnOrderingPositions(FormRequest formRequest)
        {
            return _scrappingWrapper.GetOrderingPositions(formRequest.Keywords, formRequest.Url);
        }
    }
}
