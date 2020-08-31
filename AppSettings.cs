using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace InfoTrack
{
    public class AppSettings : IAppSettings
    {
        public string HtmlToMatch => WebConfigurationManager.AppSettings["HtmlToMatch"];
        public string GoogleUrl => WebConfigurationManager.AppSettings["GoogleUrl"];
        public string NumberOfResults => WebConfigurationManager.AppSettings["NumberOfResults"];
        public string NoResultsMessage => WebConfigurationManager.AppSettings["NoResultsMessage"];
        public string EnterValuesMessage => WebConfigurationManager.AppSettings["EnterValuesMessage"];

    }
}