using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Models.Poco;
using Sss.GvErlenacker.Services;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class SearchResultPageController : RenderMvcController
    {

        private readonly ISearchService _searchService;

        public SearchResultPageController(ISearchService searchService)
        {
            _searchService = searchService;
        }



    }
}