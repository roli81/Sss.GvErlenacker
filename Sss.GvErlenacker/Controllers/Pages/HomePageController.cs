using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Services;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class HomePageController : RenderMvcController
    {
        private readonly IHomePageService _homePageService;
        private readonly INavigationService _navigationService;
   




        public HomePageController(IHomePageService homePageService, INavigationService navigationService)
        {
            _navigationService = navigationService;

            _homePageService = homePageService;
        }

        // GET: HomePage
        public ActionResult Index(ContentModel model)
        {
   
            return base.Index(_homePageService.GetHomePage(model.Content));
        }
    }
}