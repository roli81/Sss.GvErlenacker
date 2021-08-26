using System.Data.Entity;
using Sss.GvErlenacker.DomainLayer.DataLayer.Entities;
using Sss.GvErlenacker.Newsletter.DomainLayer.DataLayer.Entities;

namespace Sss.GvErlenacker.Newsletter.DomainLayer.DataLayer.Context
{
    public class NewsletterContext : DbContext
    {
        public DbSet<NewsletterUser> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
        public DbSet<DispatchRun> DispatchRuns { get; set; }

        public NewsletterContext() : base("name=Newsletter")
        {
            
        }
        
    }
}
