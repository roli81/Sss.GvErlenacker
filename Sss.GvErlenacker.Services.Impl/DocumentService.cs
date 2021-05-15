using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Models.Poco;
using Sss.Mutobo.Interfaces.Services;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Services.Impl
{
    public class DocumentService : BaseService, IDocumentService
    {
        private IImageService _imageService;

        public DocumentService(IImageService imageService)
        {
            _imageService = imageService;
        }


        public IEnumerable<Document> GetDocuments(IEnumerable<IPublishedContent> mediaNodes)
        {
            return mediaNodes.Select(mn => new Document() {Label = mn.Name, Link = mn.Url()});
        }

        public DocumentListPage GetDocumentListModel(IPublishedContent content)
        {
            var list = new List<DocumentListModel>();

            var contentPages = CurrentHelper
                .ContentAtRoot()
                .DescendantsOrSelf<IPublishedContent>()
                .Where(c => c.ContentType.CompositionAliases.Contains("basePage"));

            foreach (var page in contentPages)
            {
                var pageReleaseDate = page.HasProperty("releaseDate") && page.HasValue("releaseDate")
                    ? page.Value<DateTime>("releaseDate")
                    : page.CreateDate;

                if (page.HasProperty("documents"))
                {
                    if (list.All(r => r.ReleaseDate.Year != pageReleaseDate.Year))
                        list.Add(new DocumentListModel() { ReleaseDate = pageReleaseDate });

                    if (page.HasValue("documents"))
                    {
                        DocumentListModel first = null;
                        foreach (var dl in list)
                        {
                            if (dl.ReleaseDate.Year == pageReleaseDate.Year)
                            {
                                first = dl;
                                break;
                            }
                        }

                        first?.Documents.AddRange(GetDocuments(page.Value<IEnumerable<IPublishedContent>>("documents")));
                    }
                }
            }

            return new DocumentListPage(content)
            {
                DocumentLists = list.OrderByDescending(r => r.ReleaseDate.Year), 
                EmotionImage = _imageService.GetImage(content.Value<IPublishedContent>("emotionImage"), width: 1050)
            }; 
        }
    }
}
