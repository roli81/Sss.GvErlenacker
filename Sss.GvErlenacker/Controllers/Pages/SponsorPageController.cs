using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPoco;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Services;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class SponsorPageController : RenderMvcController
    {
        private readonly ISponsorService _sponsorService;

        public SponsorPageController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        // GET: SponsorPage
        // GET: NewsPage
        public ActionResult Index(ContentModel model)
        {
            return base.Index(_sponsorService.GetSponsorListModel());
        }
    }
}