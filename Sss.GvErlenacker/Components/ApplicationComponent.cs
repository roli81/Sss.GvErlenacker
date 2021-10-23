using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using Examine;
using Examine.Providers;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Services;
using Sss.GvErlenacker.Services.Impl;
using Sss.Mutobo.Services;
using Umbraco.Core.Composing;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Examine;
using Umbraco.Web;

namespace Sss.GvErlenacker.Components
{
    public class ApplicationComponent : IComponent
    {

        private readonly IExamineManager _examineManager;
        private readonly IUmbracoContextFactory _contextFactory;



        public ApplicationComponent(IExamineManager examineManager, IUmbracoContextFactory contextFactory)
        {
            _examineManager = examineManager;
            _contextFactory = contextFactory;
  
        }
       



     



        public void Initialize()
        {
            var externalIndex = _examineManager.Indexes.FirstOrDefault(f => f.Name == "ExternalIndex");

            if (externalIndex == null)
                throw new Exception("Search Index not found");

            externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition("sponsors", FieldDefinitionTypes.FullText));
            ((BaseIndexProvider)externalIndex).TransformingIndexValues += OnTransformingIndexValues;

            RouteTable.Routes.Ignore("{*botdetect}",
              new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
 
        }


        private void OnTransformingIndexValues(object sender, IndexingItemEventArgs e)
        {

            if (e.ValueSet.Category == IndexTypes.Content && e.ValueSet.ItemType == "sponsorPage")
            {
                var combinedFields = new StringBuilder();

                using (var ctx = _contextFactory.EnsureUmbracoContext())
                {

                    var sponsors = ctx.UmbracoContext.Content.GetById(1296).Children;

                    foreach (var sponsor in sponsors)
                    {
                        if (sponsor.IsPublished())
                        {
                            if (sponsor.ContentType.Alias == "businessSponsor")
                            {
                                combinedFields.Append(
                                    $"{sponsor.Value<string>("factoryName")}, {sponsor.Value<string>("zipCode")} {sponsor.Value<string>("city")} ");
                            }
                            else
                            {
                                combinedFields.Append(
                                $"{sponsor.Value<string>("surname")} {sponsor.Value<string>("firstname")}, {sponsor.Value<string>("zipCode")} {sponsor.Value<string>("city")} ");
                            }
                        }

                    }



                    e.ValueSet.Add("sponsors", combinedFields.ToString());
                }






            }


        }





        public void Terminate()
        {

        }
    }
}