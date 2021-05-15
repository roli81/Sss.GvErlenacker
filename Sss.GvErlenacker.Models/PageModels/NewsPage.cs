using Sss.GvErlenacker.Models.Poco;
using StackExchange.Profiling.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.Mutobo.Modules;
using Sss.Mutobo.Poco;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Models.PageModels
{
    public class NewsPage : BasePage
    {
       

        public string PageContent => Content.Value<string>("content");

        public bool ShowOnStartPage => Content.Value<bool>("showOnStartPage");
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<Document> Documents { get; set; }

        public IEnumerable<MutoboContentModule> Modules { get;set; }



        public NewsPage(IPublishedContent content) : base(content)
        {

        }
    }
}
