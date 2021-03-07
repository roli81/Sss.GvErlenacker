using System.Collections.Generic;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Services
{
    public interface INewsService
    {
        IEnumerable<NewsPage> GetLatestNews(int count = -1);
        NewsPage GetNews(IPublishedContent content);
        BlogModel GetBlogModel(IPublishedContent content);
        BasePage GetBasePageModel(IPublishedContent content);
    }
}