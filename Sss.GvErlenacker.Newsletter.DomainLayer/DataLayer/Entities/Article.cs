using Sss.GvErlenacker.DomainLayer.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Newsletter.DomainLayer.DataLayer.Entities
{
    public class Article
    {
        [Key]
        public Guid ArticleID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsEvent { get; set; }
        public DateTime? EventDate { get; set; }
        public string Content { get; set; }

        public Guid? DispatchRunId { get; set; }
        [ForeignKey("DispatchRunId")]
        public DispatchRun DispatchRun { get; set; }

    }
}
