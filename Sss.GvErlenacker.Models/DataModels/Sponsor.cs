using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Sss.GvErlenacker.Models.DataModels
{
    public class Sponsor : ContentModel
    {

        public string Surname => Content.Value<string>("surname");
        public string Firstname => Content.Value<string>("firstname");
        public string Street => Content.Value<string>("street");
        public string Number => Content.Value<string>("number");
        public string ZipCode => Content.Value<string>("zipCode");
        public string City => Content.Value<string>("city");



        public Sponsor(IPublishedContent content) : base(content)
        {
        }
    }
}
