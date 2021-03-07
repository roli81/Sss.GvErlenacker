using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace Sss.GvErlenacker.Models.DataModels
{
    public class SponsorListModel : ContentModel
    {
        public BusinessSponsor PremiumSponsor { get; set; }
        public IEnumerable<BusinessSponsor> BusinessSponsors { get; set; }
        public IEnumerable<Sponsor> Sponsors{ get; set; }

        public SponsorListModel(IPublishedContent content) : base(content)
        {

        }
    }
}
