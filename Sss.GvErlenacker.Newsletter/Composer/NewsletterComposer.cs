
using Sss.GvErlenacker.Newsletter.Components;
using Sss.GvErlenacker.Newsletter.Interfaces;
using Sss.GvErlenacker.Newsletter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Sss.GvErlenacker.Newsletter.Composer
{

    public class NewsletterComposer : ComponentComposer<NewsletterComponent>, IUserComposer
    {

        public override void Compose(Composition composition)
        {
            composition.Register(typeof(INewsletterService), typeof(NewsletterService), Lifetime.Singleton);
            base.Compose(composition);
        }



    }
}
