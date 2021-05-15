using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sss.Mutobo.Constants;
using Sss.Mutobo.Interfaces;
using Sss.Mutobo.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.Mutobo.Modules
{
    public class NewsletterModule : MutoboContentModule, IModule
    {
       


        public IPublishedContent SubscribersRoot => this.HasValue(DocumentTypes.NewsletterModule.Fields.Subscribers)
            ? this.Value<IPublishedContent>(DocumentTypes.NewsletterModule.Fields.Subscribers)
            : null;


        public NewsletterModule(IPublishedElement content, string viewName) : base(content, viewName)
        {
        }


    }
}