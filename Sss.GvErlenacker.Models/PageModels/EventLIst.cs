using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Models.PageModels
{
    public class EventList : BasePage
    {
        public IEnumerable<Event> Events { get; set; }


        public EventList(IPublishedContent content) : base(content)
        {


        }
    }
}
