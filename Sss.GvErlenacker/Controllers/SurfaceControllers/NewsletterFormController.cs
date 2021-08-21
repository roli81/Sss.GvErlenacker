using System.Web.Mvc;
using Sss.GvErlenacker.Services;
using Sss.Mutobo.Poco;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
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

            if (!_newsLetterService.IsAlreadyRegistered(model.EMail))
                _newsLetterService.Subscribe(model);
            else
                return RedirectToCurrentUmbracoPage("view=registered");

            return RedirectToCurrentUmbracoPage("view=success");
        }
    }
}