using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack
{
    public interface IAppSettings
    {
        string HtmlToMatch { get; }
        string GoogleUrl { get; }
        string NumberOfResults { get; }
        string NoResultsMessage { get; }
        string EnterValuesMessage { get; }
    }
}
