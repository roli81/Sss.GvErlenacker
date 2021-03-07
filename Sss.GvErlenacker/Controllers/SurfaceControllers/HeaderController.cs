using Sss.GvErlenacker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
 
    public class HeaderController : SurfaceController
    {
        private readonly IConfigService _configService;

        public HeaderController(IConfigService configService)
        {
            _configService = configService;
        }

        public ActionResult Index()
        {
            var model = _configService.GetHeaderConfig(CurrentPage);
  
                return View("~/Views/Partials/Header.cshtml", model);

        }


    }
}