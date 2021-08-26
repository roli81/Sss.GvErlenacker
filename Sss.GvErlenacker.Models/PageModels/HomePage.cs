using Sss.GvErlenacker.Models.Poco;
using Sss.Mutobo.Modules;
using StackExchange.Profiling.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Models.PageModels
{
    public class HomePage : BasePage
    {
        public string HomePageContent => Content.Value<string>("content"); 
        public IEnumerable<MutoboContentModule> Modules { get; set; }
   
   
        public HomePage(IPublishedContent content) : base(content)
        {
        }
    }
}