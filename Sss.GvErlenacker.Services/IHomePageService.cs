using Sss.GvErlenacker.Models.PageModels;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Services
{
    public interface IHomePageService
    {

        HomePage GetHomePage(IPublishedContent content);
    }
}