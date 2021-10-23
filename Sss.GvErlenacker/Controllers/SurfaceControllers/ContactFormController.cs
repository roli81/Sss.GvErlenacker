using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
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
       [CaptchaValidationActionFilter("CaptchaCode", "Captcha", "Bitte geben SIe den richtigen Code ein")]
        public ActionResult Index(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();



            _mailservice.SendContactMail(model);
            _mailservice.SendMessageReceivedMail(model);
            MvcCaptcha.ResetCaptcha("Captcha");
            return RedirectToUmbracoPage(1677);
        }


    }
}