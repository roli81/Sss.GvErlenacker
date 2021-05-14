using Sss.Mutobo.Interfaces;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.Mutobo.Modules
{
    public class MutoboContentModule : PublishedElementModel, IModule
    {

        public string Title { get; }

        public MutoboContentModule(IPublishedElement content) : base(content)
        {
        }

    }
}
