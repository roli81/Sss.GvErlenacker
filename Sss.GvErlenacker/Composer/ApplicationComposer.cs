using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sss.GvErlenacker.Components;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Sss.GvErlenacker.Composer
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class ApplicationComposer : ComponentComposer<ApplicationComponent>, IUserComposer
    {
        public override void Compose(Composition composition)
        {
            // ApplicationStarting event in V7: add IContentFinders, register custom services and more here
            base.Compose(composition);
        }
    }
}