using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.DataModels;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Models.PageModels
{
    public class DocumentListPage : BasePage
    {
        public IEnumerable<DocumentListModel> DocumentLists { get; set; }

        public DocumentListPage(IPublishedContent content) : base(content)
        {
        }
    }
}
