using Sss.GvErlenacker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers
{
    

    public class XmlSitemapController : RenderMvcController
    {
        private readonly IXmlSitemapService _xmlSitemapService;

        public XmlSitemapController(IXmlSitemapService xmlSitemapService)
        {
            _xmlSitemapService = xmlSitemapService;
        }


        // GET: XmlSitemap
        public ActionResult Index(ContentModel model)
        { 
            return View("~/Views/XmlSiteMap.cshtml", _xmlSitemapService.GetSitemap(model.Content));
        }
    }
}