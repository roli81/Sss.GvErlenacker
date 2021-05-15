using Sss.GvErlenacker.Services;
using System.Web.Mvc;
using Sss.Mutobo.Interfaces;
using Umbraco.Core.Services;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class NewsPageController : RenderMvcController
    {
        private readonly INewsService _newsService;
        private readonly IMutoboContentService _contentService;

        public NewsPageController(INewsService newsService, IMutoboContentService contentService)
        {
            _newsService = newsService;
            _contentService = contentService;
        }


        // GET: NewsPage
        public ActionResult Index(ContentModel model)
        {
            var typedModel = _newsService.GetNews(model.Content);
            typedModel.Modules = _contentService.GetModules(model.Content, "modules");
            return base.Index(typedModel);

        }
    }
}