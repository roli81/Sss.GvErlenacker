using System;
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
    public abstract class MutoboContentModule : PublishedElementModel
    {

        public string ViewName { get;  }

        public string Title { get; }
        public virtual IHtmlString RenderModule(HtmlHelper helper)
        {
            throw new NotImplementedException();
        }


        protected MutoboContentModule(IPublishedElement content, string viewName) : base(content)
        {
            ViewName = viewName;
        }
    }
}
