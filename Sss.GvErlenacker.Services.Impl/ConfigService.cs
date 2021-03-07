using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Lucene.Net.Util;
using NPoco.ArrayExtensions;
using Sss.GvErlenacker.Models.ConfigModels;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Services.Impl
{
    public class ConfigService : BaseService, IConfigService
    {
        private readonly IImageService _imageService;
        private readonly ISponsorService _sponsorService;

        public ConfigService(IImageService imageService, ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
            _imageService = imageService;
        }

        public FooterConfig GetFooterConfig()
        {
            var config = CurrentHelper.ContentAtRoot().First(c => c.ContentType.Alias == "configFolder")?.Children
                .First(c => c.ContentType.Alias == "footerConfig");
            
            if (config == null)
                throw new NodeNotFoundException(message: "no footer configuration found");

            var result = new FooterConfig
            {
                LinkListTitle = config.Value<string>("linkListTitle"),
                PremiumSponsorTitle = config.Value<string>("premiumSponsorTitle"),
                LinkList = config.Children.Select(c => new Link
                {
                    Text = c.HasValue("linkText") ? c.Value<string>("linkText") : c.Name,
                    Href = c.Value<string>("linkUrl"),
                    OpenInNewWindow = c.Value<bool>("openInNewWindow")
                }),
                PremiumSponsor = _sponsorService.GetPremiumSponsor()
           
            };

            return result;
        }



        public HeaderConfig GetHeaderConfig(IPublishedContent currentPage)
        {
            var config = CurrentHelper.ContentAtRoot().First(c => c.ContentType.Alias == "configFolder")?.Children
                .First(c => c.ContentType.Alias == "headerConfig");


            if (config == null)
                throw new NodeNotFoundException(message: "no header configuration found");

            var result = new HeaderConfig(config) {
                Logo = _imageService.GetImage(config.Value("logo") as IPublishedContent, height: 150),
                BackLink = currentPage.Parent?.Url ?? string.Empty
            };
            if (config.HasValue("headerCarousel"))
            {
                result.HeaderCarousel =
                    _imageService.GetImages(config.Value<IEnumerable<IPublishedContent>>("headerCarousel"), height: 250,
                        width: 1200);
                
            }
            else
            {
                result.HeaderCarousel = new List<Image>();
            }

            return result;
        }

        public SeoConfig GetSeoConfig() 
        {

            IPublishedContent config = CurrentHelper.ContentAtRoot().First(c => c.ContentType.Alias == "configFolder")?.Children
                .First(c => c.ContentType.Alias == "seoConfig");
            IPublishedContent currentPage = Umbraco.Web.Composing.Current.UmbracoHelper.AssignedContentItem;
            if (config == null)
            {
                throw new Exception("Config not found!");
            }
            return new SeoConfig
            {
                MetaDescription = config.Value<string>("metaDescription") + " " + currentPage.Value<string>("metaDescription"),
                MetaKeywords = config.Value<string>("metaKeywords") + ", " + currentPage.Value<string>("metaKeywords"),
                Logo =  GetHeaderConfig(currentPage).Logo
            };

        }

        public EMailConfig GetEMailConfig(int id)
        {
            IPublishedContent config = CurrentHelper.Content(id);

            if (config == null)
                throw new Exception("Config not found");

            return new EMailConfig()
            {
                Body = config.HasValue("body") ? config.Value<string>("body") : string.Empty,
                Subject = config.HasValue("subject") ? config.Value<string>("subject") : string.Empty,
                Footer = config.HasValue("footer") ? config.Value<string>("footer") : string.Empty,
                SalutationFemale = config.HasValue("salutationFemale") ? config.Value<string>("salutationFemale") : string.Empty,
                SalutationMale = config.HasValue("salutationMale") ? config.Value<string>("salutationMale") : string.Empty,
                SenderEmail = config.Value<string>("senderEmail"),
                ReceiverEMails = config.HasValue("receiverEmails") ? config.Value<string>("receiverEmails").Split(new char[]{ ';' }, StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>()
            };
        }
    }
}
