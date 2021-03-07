using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Services.Impl
{
    public class FormService : IFormService
    {
        private readonly IImageService _imageService;

        public FormService(IImageService imageService)
        {
            _imageService = imageService;
        }

        public FormPage GetFormPageModel(IPublishedContent content)
        {
            var result = new FormPage(content);

            result.EmotionImage = _imageService.GetImage(content.Value<IPublishedContent>("emotionImage"));
            result.MemberFormModel = new MemberFormModel()
            {
                LabelName = result.LabelName,
                LabelCompany = result.LabelCompany,
                LabelPhone = result.LabelPhone,
                LabelFirstName = result.LabelFirstName,
                LabelStreet = result.LabelStreet,
                LabelWebsite = result.LabelWebsite,
                LabelZipCity = result.LabelZipCity,
                LabelEmail = result.LabelEmail,
                LabelLogo = result.LabelLogo,
                LabelSalutation = result.LabelSalutation
            };


            return result;
        }
    }
}
