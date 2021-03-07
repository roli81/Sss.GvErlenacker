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
    public class BreadcrumbController : SurfaceController
    {
        private readonly INavigationService _navigationService;


        public BreadcrumbController(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        // GET: Breadcrumb
        public ActionResult Index()
        {
            if (CurrentPage.GetTemplateAlias() != "homePage")
            {
                return View("~/Views/Partials/Breadcrumb.cshtml", _navigationService.GetBreadCrumbNavigation());
            }
            else
            {
                return new EmptyResult();
            }

            
        }
    }
}