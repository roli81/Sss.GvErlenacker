using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;
using Umbraco.Web.Composing;

namespace Sss.GvErlenacker.Services.Impl
{
    public abstract class BaseService
    {
        protected UmbracoHelper CurrentHelper => Current.UmbracoHelper;
        protected UmbracoContext CurrentContext => Current.UmbracoContext;
    }
}
