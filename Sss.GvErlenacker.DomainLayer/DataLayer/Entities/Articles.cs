using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.DomainLayer.DataLayer.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsEvent { get; set; }
        public DateTime? EventDate { get; set; }
        public string Content { get; set; }
    }
}
