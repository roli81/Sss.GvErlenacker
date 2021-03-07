using Sss.GvErlenacker.Services;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class NewsPageController : RenderMvcController
    {
        INewsService _newsService;

        public NewsPageController(INewsService newsService)
        {
            _newsService = newsService;

        }


        // GET: NewsPage
        public ActionResult Index(ContentModel model) 
        {
            return base.Index(_newsService.GetNews(model.Content));

        }
    }
}