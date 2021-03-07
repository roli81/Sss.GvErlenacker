using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Models.Poco;
using Sss.GvErlenacker.Services;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
    public class SearchFormController : SurfaceController
    {

        private readonly ISearchService _searchService;


        public SearchFormController(ISearchService searchService)
        {
            _searchService = searchService;
        }


        [HttpPost]
        public ActionResult Search(SearchFormModel model)
        {
            if (ModelState.IsValid)
            {
    
                return View("~/Views/SearchResultPage.cshtml", _searchService.PerformSearch(model.SearchQuery));
            }
            return new EmptyResult();
        }


    }
}