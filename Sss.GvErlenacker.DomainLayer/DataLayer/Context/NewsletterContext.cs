using System.Data.Entity;
using Sss.GvErlenacker.DomainLayer.DataLayer.Entities;

namespace Sss.GvErlenacker.DomainLayer.DataLayer.Context
{
    public class NewsletterContext : DbContext
    {
        public DbSet<NewsletterUser> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Dispatches> Dispatches { get; set; }


        public NewsletterContext() : base("name=Newsletter")
        {
            
        }

    }
}
