using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.Mutobo.DataLayer.Entities;


namespace Sss.Mutobo.DataLayer.Context
{
    public class NewsletterContext : DbContext
    {
        public DbSet<NewsletterUser> Users { get; set; }



        public NewsletterContext() : base("name=Newsletter")
        {
            
        }

    }
}
