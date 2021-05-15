using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.Poco;
using Sss.Mutobo.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Sss.GvErlenacker.Models.DataModels
{
    public class BoardMember : PublishedElementModel
    {
        public string Name =>  GetProperty("surname").Value<string>();
        public string FirstName => GetProperty("firstname").Value<string>();
        public string Function => GetProperty("function").Value<string>();
        public Image Image { get; set; }


        public BoardMember(IPublishedElement content) : base(content)
        {
            
        }
    }
}
