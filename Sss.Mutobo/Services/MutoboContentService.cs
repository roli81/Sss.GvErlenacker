using System.Collections.Generic;
using Sss.Mutobo.Constants;
using Sss.Mutobo.Interfaces;
using Sss.Mutobo.Interfaces.Services;
using Sss.Mutobo.Modules;
using Sss.Mutobo.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.Mutobo.Services
{
    public class MutoboContentService : IMutoboContentService
    {
        private readonly IImageService _imageService;

        public MutoboContentService(IImageService imageService)
        {
            _imageService = imageService;
        }
        

        public IEnumerable<MutoboContentModule> GetModules(IPublishedContent content, string fieldName)
        {
            var result = new List<MutoboContentModule>();

            var modules = content.Value<IEnumerable<IPublishedElement>>(fieldName);

            foreach (var module in modules)
            {
                switch (module.ContentType.Alias)
                {
                    case DocumentTypes.NewsletterModule.Alias:
                        result.Add(new NewsletterModule(module, "NewsletterForm"));
                        break;
                    case DocumentTypes.CarouselModule.Alias:
                        result.Add(new CarouselModule(module, "Carousel")
                        {
                            Images = module.HasProperty(DocumentTypes.CarouselModule.Fields.Images) ? 
                                _imageService.GetImages(module.Value<IEnumerable<IPublishedContent>>(DocumentTypes.CarouselModule.Fields.Images))
                                : new List<Image>()
                        });
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}
