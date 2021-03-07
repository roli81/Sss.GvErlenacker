using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
    public class EvenListController : SurfaceController
    {
        // GET: EvenList
        public ActionResult Index()
        {
            
            return View("~/Views/Partials/EventsList.cshtml");
        }
    }
}