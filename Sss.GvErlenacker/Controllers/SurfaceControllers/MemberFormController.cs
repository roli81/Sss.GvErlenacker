using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Models.Poco;
using Sss.GvErlenacker.Services;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using IMemberService = Sss.GvErlenacker.Services.IMemberService;


namespace Sss.GvErlenacker.Controllers.SurfaceControllers
{
    public class MemberFormController : SurfaceController
    {

        private readonly IMemberService _memberService;
        private readonly IMailService _mailService;
        private readonly IMediaService _mediaService;

        public MemberFormController(IMemberService memberService, IMailService mailService, IMediaService mediaService)
        {
            _mediaService = mediaService;
            _memberService = memberService;
            _mailService = mailService;
        }



        [System.Web.Mvc.HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "Captcha", "Bitte geben Sie den richtigen Code ein")]
        public ActionResult Submit(MemberFormModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            IMedia media = null;
            if (model.Logo != null)
            {
                var fileName = model.Logo.FileName;
                var mediaType = Constants.Conventions.MediaTypes.Image;
                media = _mediaService.CreateMedia(fileName, 1304, mediaType);
                media.SetValue(Services.ContentTypeBaseServices, "umbracoFile", "filename1.png", model.Logo);
                _mediaService.Save(media);
            }


            _mailService.SendConfirmMail(model);
            _mailService.SendInfoMail(model);
            _memberService.RegisterMember(model, media);




            // Work with form data here
            MvcCaptcha.ResetCaptcha("Captcha");
            return RedirectToUmbracoPage(1528);

        }
    }
}