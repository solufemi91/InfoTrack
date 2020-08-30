using InfoTrack.Models;
using InfoTrack.Wrapper;
using System.Threading.Tasks;
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
        public async Task<string> ReturnOrderingPositionsAsync(FormRequest formRequest)
        {
            return await _scrappingWrapper.GetOrderingPositionsAsync(formRequest.Keywords, formRequest.Url);
        }
    }
}
