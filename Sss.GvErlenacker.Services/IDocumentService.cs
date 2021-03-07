using System.Collections.Generic;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Services
{
    public interface IDocumentService
    {
        IEnumerable<Document> GetDocuments(IEnumerable<IPublishedContent> mediaNodes);
        DocumentListPage GetDocumentListModel(IPublishedContent content);
    }
}