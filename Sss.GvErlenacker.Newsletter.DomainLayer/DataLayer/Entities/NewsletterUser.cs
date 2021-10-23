using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sss.GvErlenacker.Newsletter.DomainLayer.DataLayer.Entities
{
    public class NewsletterUser
    {
        [Key]
        public Guid NewsletterUserID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string  Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime? RegisterDate { get; set; }
        public virtual IEnumerable<Dispatch> Dispatches { get; set; }

    }
}
