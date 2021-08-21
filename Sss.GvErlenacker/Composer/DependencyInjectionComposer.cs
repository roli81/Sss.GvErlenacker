using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Sss.GvErlenacker.Services;
using Sss.GvErlenacker.Services.Impl;
using Sss.Mutobo.Interfaces;
using Sss.Mutobo.Interfaces.Services;
using Sss.Mutobo.Services;
using Umbraco.Core.Composing;
using Hangfire;
using Hangfire.SqlServer;
using Sss.GvErlenacker.DomainLayer.DataLayer.Context;
using Sss.GvErlenacker.DomainLayer.DataLayer.Entities;
using Umbraco.Web;
using GlobalConfiguration = Hangfire.GlobalConfiguration;

namespace Sss.GvErlenacker.Composer
{
    public class DependencyInjectionComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register(typeof(IHomePageService), typeof(HomePageService), Lifetime.Scope);
            composition.Register(typeof(IConfigService), typeof(ConfigService), Lifetime.Scope);
            composition.Register(typeof(IImageService), typeof(ImageService), Lifetime.Scope);
            composition.Register(typeof(INavigationService), typeof(NavigationService), Lifetime.Scope);
            composition.Register(typeof(INewsService), typeof(NewsService), Lifetime.Scope);
            composition.Register(typeof(ISponsorService), typeof(SponsorService), Lifetime.Scope);
            composition.Register(typeof(IXmlSitemapService), typeof(XmlSitemapService), Lifetime.Scope);
            composition.Register(typeof(ISectionService), typeof(SectionService), Lifetime.Scope);
            composition.Register(typeof(IFormService), typeof(FormService), Lifetime.Scope);
            composition.Register(typeof(IMemberService), typeof(MemberService), Lifetime.Scope);
            composition.Register(typeof(IMailService), typeof(MailService), Lifetime.Scope);
            composition.Register(typeof(ISearchService), typeof(SearchService), Lifetime.Scope);
            composition.Register(typeof(IEventService), typeof(EventService), Lifetime.Scope);
            composition.Register(typeof(IDocumentService), typeof(DocumentService), Lifetime.Scope);
            composition.Register(typeof(IMemberBoardService), typeof(MemberBoardService), Lifetime.Scope);
            composition.Register(typeof(INewsLetterService), typeof(NewsletterService), Lifetime.Scope);
            composition.Register(typeof(IMutoboContentService), typeof(MutoboContentService), Lifetime.Scope);
            HangfireAspNet.Use(GetHangfireServers);
            // Let's also create a sample background job
         
            

        }




        private IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Data Source=(local);Initial Catalog=GVEA_NEWSLETTER;user id=gveaUser;password=3rl3n4cker!", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                });

            yield return new BackgroundJobServer();
        }
    }
}