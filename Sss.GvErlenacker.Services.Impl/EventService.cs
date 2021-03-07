using System;
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
    public class EventService : BaseService, IEventService
    {
        private readonly IImageService _imageService;
        private readonly IDocumentService _documentService;


        public EventService(IImageService imageService, IDocumentService documentService)
        {
            _imageService = imageService;
            _documentService = documentService;
        }


        public Event GetEventDetail(IPublishedContent content)
        {
            return new Event(content)
            {
                EmotionImage = content.HasProperty("emotionImage") && content.HasValue("emotionImage")
                    ? _imageService.GetImage(content.Value<IPublishedContent>("emotionImage"))
                    : null,
                Images = content.HasProperty("images") && content.HasValue("images")
                    ? _imageService.GetImages(content.Value<IEnumerable<IPublishedContent>>("images"), width: 500)
                    : new List<Image>(),
                Documents = content.HasProperty("documents") && content.HasValue("documents")
                    ? _documentService.GetDocuments(content.Value<IEnumerable<IPublishedContent>>("documents"))
                    : new List<Document>()
            };
        }

        public EventList GetEventPageModel(IPublishedContent content)
        {
            var events = CurrentHelper.Content(1608).Children.Select(c => new Event(c));
            return new EventList(content){ Events = events, EmotionImage = _imageService.GetImage(content.Value<IPublishedContent>("emotionImage"), 1050, height: 300)};
        }
    }
}
