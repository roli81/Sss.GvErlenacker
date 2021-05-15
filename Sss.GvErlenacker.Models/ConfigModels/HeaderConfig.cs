using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.Poco;
using Sss.Mutobo.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace Sss.GvErlenacker.Models.ConfigModels
{
    public class HeaderConfig : ContentModel
    {
        public Image Logo { get; set; }
        public IEnumerable<Image> HeaderCarousel { get; set; }

        public string BackLink { get; set; }

        public HeaderConfig(IPublishedContent content) : base(content)
        {
        }
    }
}
