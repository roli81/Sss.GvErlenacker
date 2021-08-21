using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Web;
using Examine;
using Examine.Providers;
using Hangfire;
using Sss.GvErlenacker.DomainLayer.DataLayer.Context;
using Sss.GvErlenacker.DomainLayer.DataLayer.Entities;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Services;
using Sss.GvErlenacker.Services.Impl;
using Sss.Mutobo.Services;
using Umbraco.Core.Composing;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Examine;
using Umbraco.Web;

namespace Sss.GvErlenacker.Components
{
    public class ApplicationComponent : IComponent
    {

        private readonly IExamineManager _examineManager;
        private readonly IUmbracoContextFactory _contextFactory;



        public ApplicationComponent(IExamineManager examineManager, IUmbracoContextFactory contextFactory)
        {
            _examineManager = examineManager;
            _contextFactory = contextFactory;
  
        }
        public void InitNewsletterNews()
        {
            var entities = GetNewsletterArticles();
            


            using (var ctx = new NewsletterContext())
            {
                foreach (var entity in entities)
                {
                    var existing = ctx.Articles.FirstOrDefault(a => a.Id == entity.Id);

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

            using (var ctx =  _contextFactory.EnsureUmbracoContext())
            {
                var news = ctx.UmbracoContext.Content.GetAtRoot().DescendantsOrSelf<IPublishedContent>()
                    .Where(c => c.ContentType.Alias == "newspage")
                    .Select(c => new NewsPage(c)
                    {
                        SortDate = c.HasValue("releaseDate") ? c.Value<DateTime>("releaseDate") :
                            c.UpdateDate
                    });



                var events = ctx.UmbracoContext.Content.GetAtRoot().DescendantsOrSelf<IPublishedContent>()
                    .Where(c => c.ContentType.Alias == "event")
                    .Select(c => new Sss.GvErlenacker.Models.PageModels.Event(c)
                    {
                        SortDate = c.Value<DateTime>("dateFrom")

                    });

          

                result.AddRange(news.Select(n => new Article()
                {

                    Content = $"<div><h2>{n.Title}</h2>{GetImage(n.Content)}<p>{n.PageContent}</p><p><a href=\"{n.Content.Url(mode: UrlMode.Absolute)}\">Mehr erfahren</a></p></div>",
                    CreatedDate = n.Content.CreateDate,
                    Id = n.Content.Key
                }));

                result.AddRange(events.Select(n => new Article()
                {

                    Content = $"<div><h3>Veranstaltung</h3><h2>{n.Title}</h2>{GetImage(n.Content)}<p>{n.PageContent}</p><p><a href=\"{n.Content.Url(mode: UrlMode.Absolute)}\">Mehr erfahren</a></p></div>",
                    CreatedDate = n.Content.CreateDate,
                    Id = n.Content.Key,
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

        public void Initialize()
        {
            var externalIndex = _examineManager.Indexes.FirstOrDefault(f => f.Name == "ExternalIndex");

            if (externalIndex == null)
                throw new Exception("Search Index not found");

            externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition("sponsors", FieldDefinitionTypes.FullText));
            ((BaseIndexProvider)externalIndex).TransformingIndexValues += OnTransformingIndexValues;
            InitNewsletterNews();
        }


        private void OnTransformingIndexValues(object sender, IndexingItemEventArgs e)
        {

            if (e.ValueSet.Category == IndexTypes.Content && e.ValueSet.ItemType == "sponsorPage")
            {
                var combinedFields = new StringBuilder();

                using (var ctx = _contextFactory.EnsureUmbracoContext())
                {

                    var sponsors = ctx.UmbracoContext.Content.GetById(1296).Children;

                    foreach (var sponsor in sponsors)
                    {
                        if (sponsor.IsPublished())
                        {
                            if (sponsor.ContentType.Alias == "businessSponsor")
                            {
                                combinedFields.Append(
                                    $"{sponsor.Value<string>("factoryName")}, {sponsor.Value<string>("zipCode")} {sponsor.Value<string>("city")} ");
                            }
                            else
                            {
                                combinedFields.Append(
                                $"{sponsor.Value<string>("surname")} {sponsor.Value<string>("firstname")}, {sponsor.Value<string>("zipCode")} {sponsor.Value<string>("city")} ");
                            }
                        }

                    }



                    e.ValueSet.Add("sponsors", combinedFields.ToString());
                }






            }


        }





        public void Terminate()
        {

        }
    }
}