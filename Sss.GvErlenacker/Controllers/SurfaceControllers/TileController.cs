using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Models.Poco;
using Sss.GvErlenacker.Services;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
    public class TileController : SurfaceController
    {
        private readonly INavigationService _navigationService;

        public TileController(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }


        // GET: Tile
        public ActionResult Index()
        {
            return View("~/Views/Tile.cshtml", _navigationService.GetTileNavigation());
        }
    }
}