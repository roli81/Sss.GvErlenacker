using System.Text;
using System.Web.Mvc;

namespace Sss.Mutobo.Rendering
{
    public static class ModuleRenderer
    {
        public static MvcHtmlString RenderModules(this HtmlHelper helper)
        {
            var bld = new StringBuilder();


            return new MvcHtmlString(bld.ToString());
        }

    }
}