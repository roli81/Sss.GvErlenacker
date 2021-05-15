using System.Collections.Generic;
using Sss.Mutobo.Constants;
using Sss.Mutobo.Interfaces;
using Sss.Mutobo.Modules;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.Mutobo.Services
{
    public class MutoboContentService : IMutoboContentService
    {
        public IEnumerable<MutoboContentModule> GetModules(IPublishedContent content, string fieldName)
        {
            var result = new List<MutoboContentModule>();

            var modules = content.Value<IEnumerable<IPublishedElement>>(fieldName);

            foreach (var module in modules)
            {
                switch (module.ContentType.Alias)
                {
                    case DocumentTypes.NewsletterModule.Alias:
                        result.Add(new NewsletterModule(module, "NewsletterForm"));
                        break;

                    default:
                        break;
                }
            }

            return result;
        }
    }
}
