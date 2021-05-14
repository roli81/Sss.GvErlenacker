using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.Enums;

namespace Sss.GvErlenacker.Models.Poco
{
    public class NewsletterUser
    {
        public string EMail { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public ESalutation Salutation { get; set; }
        public string FuSb { get; set; }
        public Guid Key { get; set; }
    }
}
