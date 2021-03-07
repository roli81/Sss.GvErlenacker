using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Models.PageModels
{
    public class SearchResultsModel : BasePage
    {

        public string SearchTerm { get; set; }

        public IEnumerable<SearchResult> PageSearchResults { get; set; }
        public IEnumerable<SearchResult> SponsorSearchResults { get; set; }
        public IEnumerable<Document> DocumentSearchResults { get; set; }

        public SearchResultsModel(IPublishedContent content) : base(content)
        {
        }
    }
}
