using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Services.Impl
{
    public class NavigationService : BaseService, INavigationService
    {
        private readonly IUmbracoContextFactory _contextFactory;
        private readonly IImageService _imageService;


        public NavigationService(IUmbracoContextFactory contextFactory, IImageService imageService)
        {
            _imageService = imageService;
            _contextFactory = contextFactory;
        }


        public IEnumerable<Tile> GetTileNavigation()
        {
            var homePage = Umbraco.Web.Composing.Current.UmbracoHelper.AssignedContentItem;

            if (homePage == null)
                throw new NodeNotFoundException(message: $"no node with document type 'homePage' found");


            return homePage.Children.Where(c => c.ContentType.CompositionAliases.Contains("basePage")).Select(c => new Tile()
            {
                HideFromNavigation = c.Value<bool>("hideFromNavi"),
                Link = new Link()
                {
                    Text = string.IsNullOrEmpty(c.Value<string>("title")) ? c.Value<string>("title") : c.Name,
                    Href = c.Url
                },
                NotClickable = c.Value<bool>("notClickable"),
                Abstract = c.HasProperty("abstract") && c.HasValue("abstract") ? c.Value<string>("abstract") : string.Empty,
                Image= c.HasProperty("emotionImage") && c.HasValue("emotionImage") ? _imageService.GetImage(c.Value<IPublishedContent>("emotionImage"), 1050) : null

            }).Where(c => !c.HideFromNavigation);

        }

        public IEnumerable<Link> GetBreadCrumbNavigation()
        {
            var result = new List<Link>();
            var currentPage = Umbraco.Web.Composing.Current.UmbracoHelper.AssignedContentItem;
            
            result.Add(new Link()
            {
                Text = currentPage.Name,
                Href = currentPage.Url,
                Active = true
            });

            do
            {
                currentPage = currentPage.Parent;

                
                result.Insert(0, new Link()
                {
                    Text = currentPage.GetTemplateAlias() != "homePage" ? currentPage.Name : "Home",
                    Href = currentPage.Url,
                    Active = false
                });
                

            } while (currentPage.GetTemplateAlias() != "homePage");

            return result;

        }

        public IEnumerable<NavItem> GetSectionNavigation()
        {
            var startPage = CurrentHelper.ContentAtRoot().FirstOrDefault(c => c.ContentType.Alias == "homePage");

            if (startPage != null && !startPage.Children.Any())
            {
                startPage = startPage.Parent;
            }

            if (startPage == null)
                throw new NodeNotFoundException(message: $"no node with document type 'homePage' found");


            return startPage.Children.Where(c => c.ContentType.CompositionAliases.Contains("basePage"))
                .Select(c => new NavItem()
                {
                    HideFromNavigation = c.Value<bool>("hideFromNavi"),
                    Link = new Link()
                    {
                        Text = c.Name,
                        Href = c.Url(),

                    },
                    Children = c.Children.Where(cld => cld.ContentType.CompositionAliases.Contains("basePage"))
                        .Select(cld => new NavItem()
                        {
                            HideFromNavigation = cld.Value<bool>("hideFromNavi"),
                            Link = new Link()
                            {
                                Text = cld.Name,
                                Href = cld.Url(),

                            }

                        }).Where(ni => !ni.HideFromNavigation)
                }).Where(ni => !ni.HideFromNavigation);




        }
    }

}