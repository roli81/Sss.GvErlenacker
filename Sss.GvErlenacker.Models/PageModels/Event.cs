using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Models.PageModels
{
    public class Event : NewsPage
    {

        public DateTime DateFrom => Content.Value<DateTime>("dateFrom");
        public DateTime DateTo => Content.Value<DateTime>("dateTo");
        public string Location => Content.Value<string>("location");

        public bool UnknownDate => Content.Value<bool>("unknowDate");


        public Event(IPublishedContent content) : base(content)
        {
        }
    }
}
