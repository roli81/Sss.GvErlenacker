using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sss.Mutobo.Constants;
using Sss.Mutobo.Interfaces;
using Sss.Mutobo.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;

namespace Sss.Mutobo.Modules
{
    public class CarouselModule : MutoboContentModule, IModule
    {
        public IEnumerable<Image> Images { get; set; }


        public CarouselModule(IPublishedElement content, string viewName) : base(content, viewName)
        {
        }


        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var html = new StringBuilder();
            html.Append(helper.Partial($"~/Views/Modules/{ViewName}.cshtml", Images));
            return new MvcHtmlString(html.ToString());

        }
    }
}
