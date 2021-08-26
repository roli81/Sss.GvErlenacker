using Sss.GvErlenacker.Newsletter.DomainLayer.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.DomainLayer.DataLayer.Entities
{
    public class DispatchRun
    {
        [Key]
        public Guid DispatchRunID { get; set; }
        public DateTime? RunDate { get; set; }
        public ICollection<Dispatch> Dispatches { get;set;}


    }
}
