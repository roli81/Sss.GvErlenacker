using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Models.ConfigModels
{
    public class FooterConfig
    {
        public string LinkListTitle { get; set; }
        public string PremiumSponsorTitle { get; set; }

        public BusinessSponsor PremiumSponsor { get; set; }
        public IEnumerable<Link> LinkList { get; set; }



    }
}
