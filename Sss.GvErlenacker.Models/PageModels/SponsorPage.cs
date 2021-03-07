using Sss.GvErlenacker.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.PublishedCache;

namespace Sss.GvErlenacker.Models.PageModels
{
    public class SponsorPage : BasePage
    {
        public BusinessSponsor PremiumSponsor { get; set; }
        public IEnumerable<BusinessSponsor> BusinessSponsors { get; set; }
        public IEnumerable<Sponsor> Sponsors { get; set; }

        public SponsorPage(IPublishedContent content) : base(content)
        {
            
        }
    }
}
