using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.Poco;
using Sss.GvErlenacker.Services;
using Sss.Mutobo.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Extensions
{
    public static class HtmlHelperExtension
    {
        public static HtmlString CalendarSheet(this HtmlHelper helper, DateTime inputDate)
        {
            var result = new StringBuilder();
            result.Append($"<time datetime={inputDate.ToUniversalTime()} class='icon'>");
            result.Append($"<em>{inputDate.ToString("dddd", new CultureInfo("de-CH"))}</em>");
            result.Append($"<span class=\"day\">{inputDate.Day}</span>");
            result.Append($"<span class=\"month\">{inputDate.ToString("MMMM", new CultureInfo("de-CH"))}</span>");
            result.Append($"<span class=\"month\">{inputDate:yyyy}</span>");
            result.Append($"</time>");
            return new HtmlString(result.ToString()); 
        }

        public static HtmlString UnknownDate(this HtmlHelper helper)
        {
            var result = new StringBuilder();
            result.Append($"<time  class='icon'>");
            result.Append($"<em>unbekannt</em>");
            result.Append($"<span class=\"day\">?</span>");
            result.Append($"<span class=\"month\">unbekannt</span>");
            result.Append($"</time>");
            return new HtmlString(result.ToString());
        }


        public static int PrivateMembersCount(this HtmlHelper helper)
        {
            ISponsorService sponsorService = DependencyResolver.Current.GetService<ISponsorService>();
            return sponsorService.GetSponsors().Count(s => !(s is BusinessSponsor));
        }



        public static Image GetLogo(this HtmlHelper helper, IPublishedContent content)
        {


            IConfigService configservice = DependencyResolver.Current.GetService<IConfigService>();
            return configservice.GetHeaderConfig(content).Logo;


        }

        public static int BusinessMembersCount(this HtmlHelper helper)
        {
            ISponsorService sponsorService = DependencyResolver.Current.GetService<ISponsorService>();
            return sponsorService.GetSponsors().Count(s => s is BusinessSponsor);
        }
    }


}