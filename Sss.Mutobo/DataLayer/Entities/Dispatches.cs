using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Mutobo.DataLayer.Entities
{
    public class Dispatches
    {
        public Guid Id { get; set; }
        public DateTime DispatchDate { get; set; }
        public IEnumerable<Guid>  ArticlesSent { get; set; }

    }
}
