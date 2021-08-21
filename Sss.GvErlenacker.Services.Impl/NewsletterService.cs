using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hangfire;
using Sss.GvErlenacker.DomainLayer.DataLayer.Context;
using Sss.GvErlenacker.DomainLayer.DataLayer.Entities;
using Umbraco.Web;
using NewsletterUser = Sss.Mutobo.Poco.NewsletterUser;

namespace Sss.GvErlenacker.Services.Impl
{
    public class NewsletterService : INewsLetterService
    {
        private readonly INewsService _newsService;



        public NewsletterService(INewsService newsService)
        {
            _newsService = newsService;
            InitNewsletterNews();
            RecurringJob.AddOrUpdate("newsletterSendingJob", () => SendNewsLetter(), Cron.Monthly);
        }



        public void InitNewsletterNews()
        {

            var allNews = _newsService.GetLatestNews();

            var entities = new List<Article>();
            //Write Existing News to DB
            foreach (var news in allNews)
            {
                var bld = new StringBuilder();

                bld.Append($"<h2>{news.Title}</h2>");
                bld.Append($"<p>{news.PageContent}</p>");
                bld.Append($"<p><a href=\"{news.Content.Url()}\">mehr erfahren</a></p>");


                var entity = new Article()
                {
                    Id = news.Content.Key,
                    Content = bld.ToString()
                };

                

                entities.Add(entity);
            }

            using (var ctx = new NewsletterContext())
            {
                foreach (var entity in entities)
                {
                    var existing = ctx.Articles.FirstOrDefault(a => a.Id == entity.Id);

                    if (existing == null)
                    {
                        ctx.Articles.AddRange(entities);
                    }
                    else
                    {
                        existing.Content = entity.Content;
                    }
                }
                ctx.SaveChanges();




            }

        }

        public void SendNewsLetter()
        {


            using (var ctx = new NewsletterContext())
            {
    

                foreach (var user in ctx.Users)
                {
                    


                }
            }

        }

     


        private string GenerateNewsletter()
        {
            var bld = new StringBuilder();
            bld.Append("<htm>");

            return bld.ToString();

        }


        public bool IsAlreadyRegistered(string email)
        {
            using (var ctx = new NewsletterContext())
            {
                return ctx.Users.Any(u => u.Email == email);
            }
        }

        public void Subscribe(NewsletterUser user)
        {
            var entity = new Sss.GvErlenacker.DomainLayer.DataLayer.Entities.NewsletterUser()
            {
                Email = user.EMail,
                Firstname = user.FirstName,
                ID = Guid.NewGuid(),
                Lastname = user.Name,
                RegisterDate = DateTime.Now
            };

            using (var ctx = new NewsletterContext())
            {
                ctx.Users.Add(entity);
                ctx.SaveChanges();
            }
        }



        public void Unsubscribe(string email)
        {
            using (var ctx = new NewsletterContext())
            {
                var entity = ctx.Users.FirstOrDefault(u => u.Email == email);

                if (entity != null)
                {
                    ctx.Users.Remove(entity);
                }

                ctx.SaveChanges();
            }
        }
    }
}
