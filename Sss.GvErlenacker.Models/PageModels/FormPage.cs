using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Models.PageModels
{
    public class FormPage : BasePage
    {
        public string LabelName => Content.Value<string>("labelName");
        public string LabelFirstName => Content.Value<string>("labelFirstname");
        public string LabelCompany => Content.Value<string>("labelCompany");
        public string LabelStreet => Content.Value<string>("labelStreet");
        public string LabelZipCity => Content.Value<string>("labelZipCity");
        public string LabelEmail => Content.Value<string>("labelEmail");
        public string LabelPhone => Content.Value<string>("labelPhone");
        public string LabelLogo => Content.Value<string>("labelLogo");
        public string LabelWebsite => Content.Value<string>("labelWebsite");
        public string LabelSalutation => Content.Value<string>("labelSalutation");
        public string PageContent => Content.Value<string>("pageContent");


        public Guid SpamProtectKey { get; set; }

        public MemberFormModel MemberFormModel { get; set; }

        public FormPage(IPublishedContent content) : base(content)
        {
        }
    }
}
