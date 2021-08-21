using System;
using System.Collections.Generic;

namespace Sss.GvErlenacker.DomainLayer.DataLayer.Entities
{
    public class Dispatches
    {
        public Guid Id { get; set; }
        public DateTime? DispatchDate { get; set; }
        public IEnumerable<Article>  ArticlesSent { get; set; }

    }
}
