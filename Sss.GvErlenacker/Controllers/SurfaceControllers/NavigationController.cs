using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Services;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
    public class NavigationController : SurfaceController
    {
        private readonly INavigationService _navigationService;

        public NavigationController(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        // GET: Navigation
        public ActionResult Index()
        {

   
                return View("~/Views/Partials/Navigation.cshtml", _navigationService.GetSectionNavigation());



            
        }
    }
}