using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Sss.GvErlenacker.Newsletter.Composer;
using Sss.GvErlenacker.Newsletter.Interfaces;
using Sss.GvErlenacker.Newsletter.Services;
using Sss.GvErlenacker.Services;
using Sss.GvErlenacker.Services.Impl;
using Sss.Mutobo.Interfaces;
using Sss.Mutobo.Interfaces.Services;
using Sss.Mutobo.Services;
using Umbraco.Core.Composing;
using Umbraco.Web;


namespace Sss.GvErlenacker.Composer
{
    [ComposeAfter(typeof(NewsletterComposer))]
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
           
            composition.Register(typeof(IMutoboContentService), typeof(MutoboContentService), Lifetime.Scope);
            composition.Register(typeof(INewsletterRegisterService), typeof(NewsletterRegisterService), Lifetime.Singleton);

            // Let's also create a sample background job



        }





    }
}