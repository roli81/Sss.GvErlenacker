using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Examine;
using Examine.LuceneEngine.Search;
using Examine.Search;
using Lucene.Net.Index;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.PageModels;
using Sss.Mutobo.Interfaces.Services;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Examine;
using Umbraco.Web;
using SearchResult = Sss.GvErlenacker.Models.Poco.SearchResult;

namespace Sss.GvErlenacker.Services.Impl
{
    public class SearchService : BaseService, ISearchService
    {
        private readonly IImageService _imageService;
        private readonly ISponsorService _sponsorService;

        public SearchService(IImageService imageService, ISponsorService sponsorService)
        {
            _imageService = imageService;
            _sponsorService = sponsorService;
        }

        public SearchResultsModel PerformSearch(string term)
        {
            var result = new SearchResultsModel(CurrentHelper.AssignedContentItem) { SearchTerm = term };
            var pages = new List<SearchResult>();
            var sponsorResult = new List<SearchResult>();

            if (ExamineManager.Instance.TryGetIndex("ExternalIndex", out var index))
            {
                ISearcher searcher = index.GetSearcher();
                LuceneSearchQuery query = (LuceneSearchQuery)searcher.CreateQuery("content");
                query.ManagedQuery(term, new[] { "sponsors", "title", "pageContent", "content", "mainContent" });
                var results = query.Execute();

                foreach (var r in results)
                {
                    if (r.Id != null)
                    {
                        var node = CurrentHelper.Content(r.Id);

                        switch (node.ContentType.Alias)
                        {
                            case "sponsorPage":
                                sponsorResult.AddRange(MapToSponsorSearchResult(node, term));
                                break;

                            default:
                                pages.Add(new SearchResult()
                                {
                                    Url = node.Url(),
                                    Title = $"{node.Value<string>("title")}",
                                    Abstract = node.HasValue("abstract") ? $"{node.Value<string>("abstract")}" : string.Empty,
                                    EmotionImage = node.HasProperty("emotionImage") && node.HasValue("emotionImage") ?
                                        _imageService.GetImage(node.Value<IPublishedContent>("emotionImage"), width: 1050) : null,
                                    RedirectUrl = node.HasValue("redirectLink") ? node.Value<string>("redirectLink") : null
                                    
                                });
                                break;
                        }
                    }
                }

                result.PageSearchResults = pages;
                result.SponsorSearchResults = sponsorResult;
            }

            return result;
        }

        private IEnumerable<SearchResult> MapToSponsorSearchResult(IPublishedContent node, string term)
        {

            var result = new List<SearchResult>();

            if (ExamineManager.Instance.TryGetIndex("ExternalIndex", out var index))
            {
                ISearcher searcher = index.GetSearcher();
                LuceneSearchQuery query = (LuceneSearchQuery)searcher.CreateQuery("content");
                query.ManagedQuery(term).And()
                    .GroupedOr(new[] { "__NodeTypeAlias" }, new[] { "businessSponsor", "sponsor" });
                var results = query.Execute();


                var sponsorBlockBuilder = new StringBuilder("<strong>Herzlichen Dank unseren privaten Gönnern:</strong>");
                var sponsors = new List<Sponsor>();


                foreach (var r in results)
                {
                    var relatedNode = CurrentHelper.Content(r.Id);

                    if (relatedNode.ContentType.Alias == "businessSponsor")
                    {

                        var businessSponsor = new BusinessSponsor(relatedNode);

                        result.Add(new SearchResult()
                        {
                            Url = node.Url(),
                            Title = node.Value<string>("title"),
                            SponsorUrl = !string.IsNullOrEmpty(businessSponsor.Website) ? businessSponsor.Website : null,
                            EmotionImage = relatedNode.HasProperty("logo") && relatedNode.HasValue("logo") ?
                        _imageService.GetImage(relatedNode.Value<IPublishedContent>("logo"), height: 200) : null,
                            Abstract = $"{businessSponsor.FactoryName}, {businessSponsor.ZipCode} {businessSponsor.City}"
                        });
                    }
                    else
                    {
                        sponsors.Add(new Sponsor(relatedNode));
                    }
                }

                sponsors = sponsors.OrderBy(s => s.Surname).ThenBy(s => s.Firstname).ToList();
                sponsorBlockBuilder.Append("<div class=\"search-result-tile-private-sponsors \">");
                foreach (var sponsor in sponsors)
                {
                    sponsorBlockBuilder.Append(
                        $"{sponsor.Surname} {sponsor.Firstname},<br /> {sponsor.ZipCode} {sponsor.City}<br/><br/>");
                }
                sponsorBlockBuilder.Append("</div>");

                if (sponsors.Any())
                {
                    result.Add(new SearchResult()
                    {
                        Url = node.Url(),
                        Title = node.Value<string>("title"),
                        Abstract = sponsorBlockBuilder.ToString()

                    });
                }


            }





            return result;
        }
    }
}
