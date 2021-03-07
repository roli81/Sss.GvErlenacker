using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Services.Impl
{
    public class HomePageService : BaseService, IHomePageService
    {
        private readonly IImageService  _imageService;


        public HomePageService(IImageService imageService)
        {
            _imageService = imageService;
        }


        public HomePage GetHomePage(IPublishedContent content)
        {

            return new HomePage(content)
            {
                EmotionImage = _imageService.GetImage(content.Value<IPublishedContent>("emotionImage"), width: 500)
            };


        }

    }
}
