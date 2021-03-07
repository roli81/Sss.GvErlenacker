using Sss.GvErlenacker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class BlogController : RenderMvcController
    {
        private readonly INewsService _newsService;

        public BlogController(INewsService newsService)
        {
            _newsService = newsService;
        }


        // GET: Blog
        public override ActionResult Index(ContentModel model)
        {

            return base.Index(_newsService.GetBlogModel(model.Content));
        }
    }
}