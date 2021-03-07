using Sss.GvErlenacker.Models.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Services.Impl
{
    public class XmlSitemapService : BaseService, IXmlSitemapService
    {
		public IEnumerable<BasePage> GetSitemap(IPublishedContent model)
		{
			IPublishedContent homePage = CurrentHelper.ContentAtRoot().FirstOrDefault(c => c.ContentType.Alias == "homePage");
			return from n in GenerateSiteMapNodes(homePage)
				   where n.ContentType.CompositionAliases.Contains("basePage")
				   select new BasePage(n);
				   
		}

		private IEnumerable<IPublishedContent> GenerateSiteMapNodes(IPublishedContent content)
		{
			yield return content;
			if (content.Children == null)
			{
				yield break;
			}
			foreach (IPublishedContent child in content.Children)
			{
				foreach (IPublishedContent item in GenerateSiteMapNodes(child))
				{
					yield return item;
				}
			}
		}

		private string EnsureUrlStartsWithDomain(string url)
		{
			if (url.StartsWith("http"))
			{
				return url;
			}
			return string.Concat("https://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + "/", url);
		}

	}
}
