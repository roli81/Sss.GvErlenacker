using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Mutobo.DataLayer.Entities
{
    public class NewsletterUser
    {
        public Guid ID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string  Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
