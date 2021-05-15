using System.Web.Mvc;
using Sss.Mutobo.Interfaces.Services;
using Sss.Mutobo.Poco;
using Umbraco.Web.Mvc;

namespace Sss.Mutobo.SurfaceControllers
{


    public class NewsletterFormController : SurfaceController
    {

        private readonly INewsLetterService _newsLetterService;

        public NewsletterFormController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }


        // GET: NewsletterForm
        public ActionResult Index(NewsletterUser model)
        {

            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

      
            if (!string.IsNullOrEmpty(model.FuSb))
                return new EmptyResult();


            return RedirectToCurrentUmbracoPage();
        }
    }
}