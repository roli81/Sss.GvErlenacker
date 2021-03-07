using Sss.GvErlenacker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
    public class FooterController : SurfaceController
    {

        private readonly IConfigService _configService;

        public FooterController(IConfigService configService)
        {
            _configService = configService;
        }
        // GET: Footer
        public ActionResult Index()
        {
            var model = _configService.GetFooterConfig();
            
            return View("~/Views/Partials/Footer.cshtml", model);
        }
    }
}