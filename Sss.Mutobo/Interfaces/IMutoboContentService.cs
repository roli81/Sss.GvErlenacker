using System.Collections.Generic;
using Sss.Mutobo.Modules;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.Mutobo.Interfaces
{
    public interface IMutoboContentService
    {
        IEnumerable<MutoboContentModule> GetModules(IPublishedContent content, string fieldName);
    }
}