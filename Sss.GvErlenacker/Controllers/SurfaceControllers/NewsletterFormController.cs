using System.Web.Mvc;
using Sss.GvErlenacker.Newsletter.Interfaces;
using Sss.GvErlenacker.Services;
using Sss.GvErlenacker.Services.Impl;
using Sss.Mutobo.Poco;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{


    public class NewsletterFormController : SurfaceController
    {




        // GET: NewsletterForm
        public ActionResult Index(NewsletterUser model)
        {

            var nlService = (INewsletterRegisterService)DependencyResolver.Current.GetService(typeof(INewsletterRegisterService));


            if (!ModelState.IsValid)
                return CurrentUmbracoPage();


      
            if (!string.IsNullOrEmpty(model.FuSb))
                return new EmptyResult();

            if (!nlService.IsAlreadyRegistered(model.EMail))
                nlService.Subscribe(model);
            else
                return RedirectToCurrentUmbracoPage("view=registered");

            return RedirectToCurrentUmbracoPage("view=success");
        }
    }
}