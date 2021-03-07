using Sss.GvErlenacker.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;


namespace Sss.GvErlenacker.Models.PageModels
{
    public class BasePage : ContentModel
    {

        public DateTime SortDate { get; set; }


        public DateTime ReleaseDate => Content.HasValue("releaseDate") ? Content.Value<DateTime>("releaseDate") :
            Content.UpdateDate;
        public decimal SearchEngineRelativePriority =>
            Content.GetProperty("searchEngineRelativePriority").Value<decimal>();
        public string Url => Content.Url();
        public string SearchEngineChangeFrequency => Content.HasValue("searchEngineChangeFrequency") ? Content.Value<string>("searchEngineChangeFrequency") : "yearly";
        public bool HideFromXmlSitemap => Content.Value<bool>("hideFromXmlSitemap");
        public string MetaDescription => Content.Value<string>("metaDescription");
        public string MetaKeywords => Content.Value<string>("metaKeywords");
        public string Title => Content.Value<string>("title");
        public string Abstract => Content.Value<string>("abstract");
        public string RedirectLink => Content.Value<string>("redirectLink");
        public IEnumerable<BasePage> BlogEntries { get; set; }

        public Image EmotionImage { get; set; }

        public BasePage(IPublishedContent content) : base(content)
        {
           
        }
    }
}
