using Sss.GvErlenacker.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.Mutobo.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Models.PageModels
{
    public class SectionPage : BasePage
    {

        public string Abstract => Content.Value<string>("abstract");

        public string Title => Content.Value<string>("title");
        public DateTime ReleaseDate => Content.CreateDate;
        public string PageContent => Content.Value<string>("mainContent");

        public Image EmotionImage { get; set; }

        public SectionPage(IPublishedContent content) : base(content)
        { 


        
        }

    }
}
