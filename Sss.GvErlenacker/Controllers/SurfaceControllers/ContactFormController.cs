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
    public class ContactFormController : SurfaceController
    {

        private readonly IMailService _mailservice;
        public ContactFormController(IMailService mailservice)
        {
            _mailservice = mailservice;
        }


       [HttpPost]
        public ActionResult Index(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            // SPamBot Detetected!
            if (!string.IsNullOrEmpty(model.FuSb))
                return new EmptyResult();

            _mailservice.SendContactMail(model);
            _mailservice.SendMessageReceivedMail(model);

            return RedirectToUmbracoPage(1677);
        }


    }
}