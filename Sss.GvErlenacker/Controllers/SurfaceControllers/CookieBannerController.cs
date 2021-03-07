using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
    public class CookieBannerController : SurfaceController
    {
        // GET: CookieBanner
        public ActionResult Index()
        {
            return View("~/Views/SurfaceViews/CookieBanner.cshtml");
        }
    }
}