using System;
using Sss.Mutobo.Enums;

namespace Sss.Mutobo.Poco
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
