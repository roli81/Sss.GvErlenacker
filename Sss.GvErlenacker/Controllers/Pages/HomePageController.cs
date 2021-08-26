using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Services;
using Sss.Mutobo.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class HomePageController : RenderMvcController
    {
        private readonly IHomePageService _homePageService;
        private readonly INavigationService _navigationService;

        private readonly IMutoboContentService _contentService;



        public HomePageController(IHomePageService homePageService, INavigationService navigationService, IMutoboContentService contentService)
        {
            _navigationService = navigationService;

            _homePageService = homePageService;
            _contentService = contentService;
        }

        // GET: HomePage
        public ActionResult Index(ContentModel model)
        {
            var homePage = _homePageService.GetHomePage(model.Content);

            if (model.Content.HasProperty("modules") && model.Content.HasValue("modules"))
            {
                homePage.Modules = _contentService.GetModules(model.Content, "modules");
            }
            
            return base.Index(homePage);
        }
    }
}