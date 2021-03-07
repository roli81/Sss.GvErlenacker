using Sss.GvErlenacker.Models.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Services
{
    public interface IXmlSitemapService
    {
        IEnumerable<BasePage> GetSitemap(IPublishedContent model);
    }
}
