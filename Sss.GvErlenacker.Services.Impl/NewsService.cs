using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Models.Poco;
using Sss.Mutobo.Interfaces.Services;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Image = Sss.Mutobo.Poco.Image;


namespace Sss.GvErlenacker.Services.Impl
{
    public class NewsService : BaseService, INewsService
    {

        private readonly IImageService _imageService;
        private readonly IDocumentService _documentService;

        public NewsService(IImageService imageService, IDocumentService documentService)
        {
            _imageService = imageService;
            _documentService = documentService;
        }

        public BlogModel GetBlogModel(IPublishedContent content)
        {
            var result = new BlogModel(content)
            {
                EmotionImage = content.HasValue("emotionImage") ? _imageService.GetImage(content.Value<IPublishedContent>("emotionImage"), 1050) : null,
                BlogEntries = content.Children.Any() ? content.Children.Select(c => new NewsPage(c)
                {
                    EmotionImage = c.HasValue("emotionImage") ? _imageService.GetImage(c.Value<IPublishedContent>("emotionImage"), 300) : null
                }).OrderByDescending(n => n.ReleaseDate).ToList() : new List<NewsPage>()
            };

            return result;
        }

        public BasePage GetBasePageModel(IPublishedContent content)
        {
            var result = new BasePage(content)
            {
                EmotionImage = content.HasValue("emotionImage") ? _imageService.GetImage(content.Value<IPublishedContent>("emotionImage"), 1050) : null,
                BlogEntries = content.Children.Any() ? content.Children.Select(c => new NewsPage(c)
                {
                    EmotionImage = c.HasValue("emotionImage") ? _imageService.GetImage(c.Value<IPublishedContent>("emotionImage"), 200) : null
                }).OrderByDescending(n => n.ReleaseDate).ToList() : new List<NewsPage>()
            };

            return result;
        }

        public IEnumerable<NewsPage> GetLatestNews(int count = -1)
        {
            var result = new List<NewsPage>();


            var news = CurrentHelper.ContentAtRoot().DescendantsOrSelf<IPublishedContent>()
                .Where(c => c.Value<bool>("showOnStartpage") && c.ContentType.Alias == "newspage")
                .Select(c => new NewsPage(c)
                {
                    SortDate = c.HasValue("releaseDate") ? c.Value<DateTime>("releaseDate") :
                        c.UpdateDate
                });


            var events = CurrentHelper.ContentAtRoot().DescendantsOrSelf<IPublishedContent>()
                .Where(c => c.Value<bool>("showOnStartpage") && c.ContentType.Alias == "event")
                .Select(c => new Sss.GvErlenacker.Models.PageModels.Event(c)
                {
                    SortDate = c.Value<DateTime>("dateFrom")

                });

            result.AddRange(events);
            result.AddRange(news);
            result = result.OrderByDescending(n => n.SortDate).ToList();

            return count > 0 ? result.Take(count).OrderByDescending(n => n.SortDate).ToList() : result;
        }

        public NewsPage GetNews(IPublishedContent content)
        {
            var result = new NewsPage(content)
            {
                EmotionImage = content.HasProperty("emotionImage") && content.HasValue("emotionImage")
                    ? _imageService.GetImage(content.Value<IPublishedContent>("emotionImage"))
                    : null,
                Images = content.HasProperty("images") && content.HasValue("images")
                    ? _imageService.GetImages(content.Value<IEnumerable<IPublishedContent>>("images"))
                    : (IEnumerable<Image>) new List<Image>(),
                Documents = content.HasProperty("documents") && content.HasValue("documents")
                            ? _documentService.GetDocuments(content.Value<IEnumerable<IPublishedContent>>("documents"))
                            : new List<Document>()
            };

            return result;
        }
    }
}
