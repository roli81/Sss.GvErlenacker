using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Models.Enums;

namespace Sss.GvErlenacker.Models.Poco
{
    public class MemberFormModel
    {


        public string LabelName { get; set; }
        public string LabelFirstName { get; set; }
        public string LabelCompany  { get; set; }
        public string LabelStreet { get; set; }
        public string LabelZipCity { get; set; }
        public string LabelEmail { get; set; }
        public string LabelPhone { get; set; }
        public string LabelLogo { get; set; }
        public string LabelWebsite { get; set; }
        public string LabelSalutation { get; set; }
     


        public string Company { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public string FuSb { get; set; }
        public HttpPostedFileBase Logo { get; set; }

        public string CaptchaCode { get; set; }
        public ESponsorType SponsorType { get; set; }

        public IEnumerable<SelectListItem> SponsorTypes =>
            new List<SelectListItem>()
            {

                new SelectListItem()
                {
                    Value = ESponsorType.Private.ToString(),
                    Text = "natürliche Personen Fr. 50.00 Jahresbeitrag"
                },
                new SelectListItem()
                {
                    Value = ESponsorType.Business.ToString(),
                    Text = "Gewerbe Fr. 150.00 Jahresbeitrag"
                },
                new SelectListItem()
                {
                    Value = ESponsorType.Link.ToString(),
                    Text = "Gewerbe mit Link auf Homepage Fr. 300.00 Jahresbeitrag"
                }

            };

        public ESalutation Salutation { get; set; }

        public IEnumerable<SelectListItem> Salutations =>
            new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = ESalutation.None.ToString(),
                    Text = "Bitte wählen",
                    Selected = true
                },
                new SelectListItem()
                {
                    Value = ESalutation.Male.ToString(),
                    Text = "Herr"

                },
                new SelectListItem()
                {
                    Value = ESalutation.Female.ToString(),
                    Text = "Frau"
                }
            };
    }
}
