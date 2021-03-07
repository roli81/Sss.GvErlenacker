using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Models.Poco;
using Sss.GvErlenacker.Services;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class FormPageController : RenderMvcController
    {
        private readonly IFormService _formService;


        public FormPageController(IFormService formService)
        {
            _formService = formService;
        }



        // GET: FormPage
        public ActionResult Index(ContentModel model)
        {
            return base.Index(_formService.GetFormPageModel(model.Content));
        }


    }
}