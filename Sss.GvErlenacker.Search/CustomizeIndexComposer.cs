using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examine;
using Examine.LuceneEngine.Providers;
using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoExamine.PDF;


namespace Sss.GvErlenacker.Search
{
    public class CustomizeIndexComposer : ComponentComposer<CustomizeIndexComponent> { }

    public class CustomizeIndexComponent : IComponent
    {
        private readonly IExamineManager _examineManager;


        public CustomizeIndexComponent(IExamineManager examineManager)
        {
            _examineManager = examineManager;
        }


        public void Initialize()
        {




            // add a custom field type
            // modify an existing field type (not recommended)
            
        }

        public void Terminate()
        {

        }
    }
}
