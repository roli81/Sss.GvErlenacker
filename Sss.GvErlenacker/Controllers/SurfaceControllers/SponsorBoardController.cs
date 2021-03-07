using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Services;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
    public class SponsorBoardController : Controller
    {
        private readonly ISponsorService _sponsorService;



        public SponsorBoardController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        // GET: SponsorBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}