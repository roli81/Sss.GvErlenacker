using Sss.GvErlenacker.DomainLayer.DataLayer.Entities;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Newsletter.DomainLayer.DataLayer.Context;
using Sss.GvErlenacker.Newsletter.DomainLayer.DataLayer.Entities;
using Sss.GvErlenacker.Newsletter.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Newsletter.Services
{
    public class NewsletterService : INewsletterService
    {
        private readonly IUmbracoContextFactory _contextFactory;

        public NewsletterService(IUmbracoContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void InitNewsletterNews()
        {
            Debug.WriteLine("Init Newsletter");
            var entities = GetNewsletterArticles();



            using (var ctx = new NewsletterContext())
            {
                foreach (var article in ctx.Articles)
                {
                    var umbArticle = entities.FirstOrDefault(e => e.ArticleID == article.ArticleID);

                    if (umbArticle == null)
                    {
                        ctx.Articles.Remove(umbArticle);
                        ctx.SaveChanges();
                    }
                }

                foreach (var entity in entities)
                {
                    var existing = ctx.Articles.FirstOrDefault(a => a.ArticleID == entity.ArticleID);

                    if (existing == null)
                    {
                        ctx.Articles.Add(entity);
                    }
                    else
                    {
                        existing.Content = entity.Content;
                        existing.EventDate = entity.EventDate;
                        existing.IsEvent = entity.IsEvent;
                        existing.CreatedDate = entity.CreatedDate;
                    }
                }
                ctx.SaveChanges();
            }

        }



        private IEnumerable<Article> GetNewsletterArticles()
        {
            var result = new List<Article>();

            using (var ctx = _contextFactory.EnsureUmbracoContext())
            {
                var news = ctx.UmbracoContext.Content.GetAtRoot().DescendantsOrSelf<IPublishedContent>()
                    .Where(c => c.ContentType.Alias == "newspage")
                    .Select(c => new NewsPage(c)
                    {
                        SortDate = c.HasValue("releaseDate") ? c.Value<DateTime>("releaseDate") :
                            c.UpdateDate
                    }).Where(np => !string.IsNullOrEmpty(np.PageContent));

                var events = ctx.UmbracoContext.Content.GetAtRoot().DescendantsOrSelf<IPublishedContent>()
                    .Where(c => c.ContentType.Alias == "event")
                    .Select(c => new Sss.GvErlenacker.Models.PageModels.Event(c)
                    {
                        SortDate = c.Value<DateTime>("dateFrom")
                    }).Where(np => !string.IsNullOrEmpty(np.PageContent));

                result.AddRange(news.Select(n => new Article()
                {
                    Content = $"<div><h2>{n.Title}</h2>{GetImage(n.Content)}<p>{n.PageContent}</p><p><a href=\"{n.Content.Url(mode: UrlMode.Absolute)}\">Mehr erfahren</a></p></div>",
                    CreatedDate = n.Content.CreateDate,
                    ArticleID = n.Content.Key,

                }));

                result.AddRange(events.Select(n => new Article()
                {
                    Content = $"<div><h3>Veranstaltung</h3><h2>{n.Title}</h2>{GetImage(n.Content)}<p>{n.PageContent}</p><p><a href=\"{n.Content.Url(mode: UrlMode.Absolute)}\">Mehr erfahren</a></p></div>",
                    CreatedDate = n.Content.CreateDate,
                    ArticleID = n.Content.Key,
                    IsEvent = true
                }));
            }

            return result.OrderByDescending(a => a.CreatedDate);
        }

        private string GetImage(IPublishedContent content)
        {
            var hostName = ConfigurationManager.AppSettings["hostname"];
            var img = content.HasValue("emotionImage") ?
                content.Value<IPublishedContent>("emotionImage") : null;

            if (img != null)
            {
                var mediaUrl = img.GetCropUrl(800, 450);

                if (!string.IsNullOrEmpty(mediaUrl))
                    return $"<img src=\"{hostName}{mediaUrl}\"/>";

            }

            return string.Empty;
        }


        public void SendNewsLetter()
        {



            var newDispatchRun = new DispatchRun()
            {
                DispatchRunID = Guid.NewGuid(),
                RunDate = DateTime.Now

            };
            Debug.WriteLine("Send Newsletter");
            var users = GetNewsletterUsers(newDispatchRun.DispatchRunID);

            using (var ctx = new NewsletterContext())
            {
                ctx.DispatchRuns.Add(newDispatchRun);
                ctx.SaveChanges();
                var allArticles = ctx.Articles.ToList();
                var articles = new List<Article>();

                foreach (var user in users)
                {
                    foreach (var article in allArticles)
                    {
                        if (user.Dispatches == null || !user.Dispatches.ToList().Any(dp => dp.DispatchRunID == article.DispatchRunId))
                        {
                            articles.Add(article);
                            var atricleEntity = ctx.Articles.FirstOrDefault(a => a.ArticleID == article.ArticleID);
                            atricleEntity.DispatchRunId = newDispatchRun.DispatchRunID;
                        }
                        var html = GetHtmlMail(articles);
                        var dispatch = new Dispatch()
                        {
                            DispatchID = Guid.NewGuid(),
                            User = user,
                            UserID = user.NewsletterUserID,
                            DispatchDate = DateTime.Now,
                            DispatchRun = newDispatchRun,
                            DispatchRunID = newDispatchRun.DispatchRunID
                        };

                        ctx.Dispatches.Add(dispatch);

                    }
                    ctx.SaveChanges();
                }

            
            }
        }


        private IEnumerable<NewsletterUser> GetNewsletterUsers(Guid dispatchRunID)
        {
            var result = new List<NewsletterUser>();

            using (var ctx = new NewsletterContext())
            {
                result = ctx.Users.ToList();
            }

            return result;
        }



        private string GetHtmlMail(ICollection<Article> articlesToSend)
        {
            var bld = new StringBuilder();
            bld.Append("<html><head><title>Newsletter</title></head><body>");
            foreach (var article in articlesToSend)
            {
                bld.Append(article.Content);
            }
            bld.Append("</body></html>");
            return bld.ToString();
        }







        private string GenerateNewsletter()
        {
            var bld = new StringBuilder();
            bld.Append("<htm>");

            return bld.ToString();

        }

        public DateTime GetLastDispatchRun()
        {
            var result = DateTime.MinValue;

            using (var ctx = new NewsletterContext())
            {
                var lastDispatch = ctx.DispatchRuns?.Max(d => d.RunDate);

                if (lastDispatch.HasValue)
                {
                    result = lastDispatch.Value;
                }

            }

            return result;
        }
    }
}
