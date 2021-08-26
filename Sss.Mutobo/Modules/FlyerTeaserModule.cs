using Sss.Mutobo.Interfaces;
using Sss.Mutobo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Sss.Mutobo.Modules
{
    public class FlyerTeaserModule : MutoboContentModule, IModule
    {
        public FlyerTeaserModule(IPublishedElement content, string viewName) : base(content, viewName)
        {
        }

        public Image Image { get; set; }
        public string Text => this.HasValue(Constants.DocumentTypes.FlyerTeaserModule.Fields.Text) ?
            this.Value<string>(Constants.DocumentTypes.FlyerTeaserModule.Fields.Text) : null;
        public Link TargetLink => this.HasValue(Constants.DocumentTypes.FlyerTeaserModule.Fields.TargetLink) ?
            this.Value<Link>(Constants.DocumentTypes.FlyerTeaserModule.Fields.TargetLink) : null;

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var html = new StringBuilder();
            html.Append(helper.Partial($"~/Views/Modules/{ViewName}.cshtml", this));
            return new MvcHtmlString(html.ToString());

        }
    }
}
