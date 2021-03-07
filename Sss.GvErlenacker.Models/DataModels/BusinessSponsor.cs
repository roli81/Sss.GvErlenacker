using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Models.DataModels
{
    public class BusinessSponsor : Sponsor
    {
        public string FactoryName => Content.Value<string>("factoryName");
        public string Website => Content.Value<string>("website");
        public Image Logo { get; set; }
        public bool IsPremiumSponsor => Content.Value<bool>("isPremiumSponsor");


        public BusinessSponsor(IPublishedContent content) : base(content)
        {
        }
    }
}
