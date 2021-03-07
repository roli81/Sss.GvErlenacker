using Sss.GvErlenacker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class SectionPageController : RenderMvcController
    {
        private readonly ISectionService _sectionService;

        public SectionPageController(ISectionService sectionService) {
            _sectionService = sectionService;
        }

        // GET: SectionPage
        public ActionResult Index(ContentModel model)
        {
            return View(_sectionService.GetSectionPage(model.Content));
        }
    }
}