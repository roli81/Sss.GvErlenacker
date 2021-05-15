using Sss.GvErlenacker.Models.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.Mutobo.Interfaces.Services;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Services.Impl
{
    public class SectionService : ISectionService
    {
        private readonly IImageService _imageService;
        public SectionService(IImageService imageService) {
            _imageService = imageService;
        }

        public SectionPage GetSectionPage(IPublishedContent content)
        {
            return new SectionPage(content) {
                EmotionImage = content.HasProperty("emotionImage") && content.HasValue("emotionImage") ? _imageService.GetImage(content.Value<IPublishedContent>("emotionImage")) : null
            };
        }
    }
}
