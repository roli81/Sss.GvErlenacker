
using Sss.GvErlenacker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.Mutobo.Interfaces.Services;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
    public class CarouselController : SurfaceController
    {
        private readonly IImageService _imageService;

        public CarouselController(IImageService imageService) 
        {
            _imageService = imageService;
        
        }
        


        // GET: Carousel
        public ActionResult Index()
        {
            var model = _imageService.GetImages(CurrentPage.GetProperty("images")?.GetValue() as IEnumerable<IPublishedContent>, width: 1050); 
            return View("~/Views/Partials/Carousel.cshtml", model);
        }
    }
}