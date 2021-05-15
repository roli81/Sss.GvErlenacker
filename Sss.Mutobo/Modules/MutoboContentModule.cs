using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sss.Mutobo.Interfaces;
using Sss.Mutobo.Poco;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.Mutobo.Modules
{
    public class MutoboContentModule : PublishedElementModel, IModule
    {

        public string ViewName { get;  }

        public string Title { get; }
        public IHtmlString RenderModule(HtmlHelper helper)
        {
            var html = new StringBuilder();
            html.Append(helper.Partial($"~/Views/Modules/{ViewName}.cshtml", new NewsletterUser() { })); 
            return new MvcHtmlString(html.ToString());
        }


        public MutoboContentModule(IPublishedElement content, string viewName) : base(content)
        {
            ViewName = viewName;
        }
    }
}
