using System;

namespace Sss.GvErlenacker.DomainLayer.DataLayer.Entities
{
    public class NewsletterUser
    {
        public Guid ID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string  Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
