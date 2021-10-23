using Sss.GvErlenacker.DomainLayer.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sss.GvErlenacker.Newsletter.DomainLayer.DataLayer.Entities
{
    public class Dispatch
    {
        [Key]
        public Guid DispatchID { get; set; }
        public DateTime? DispatchDate { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public Guid DispatchRunID { get; set; }
        [ForeignKey("DispatchRunID")]  
        public DispatchRun DispatchRun { get; set; }
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public NewsletterUser User { get; set; }


    }
}
