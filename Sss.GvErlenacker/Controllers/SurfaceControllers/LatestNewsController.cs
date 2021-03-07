using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Services;
using Sss.GvErlenacker.Services.Impl;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
    public class LatestNewsController : SurfaceController
    {
        private readonly INewsService _newsService;


        public LatestNewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: LatestNews
        public ActionResult Index()
        {
            return View("~/Views/Partials/LatestNews.cshtml", _newsService.GetLatestNews(3));
        }
    }
}