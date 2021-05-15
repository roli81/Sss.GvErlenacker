using System.Web;
using System.Web.Mvc;
using Sss.Mutobo.Modules;

namespace Sss.Mutobo.Interfaces
{
    public interface IModule
    {
        string Title { get; }
        IHtmlString RenderModule(HtmlHelper helper);
    }
}