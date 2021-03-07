using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Services;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class DocumentListController : RenderMvcController
    {
        private readonly IDocumentService _documentService;

        public DocumentListController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: DocumentList
        public override ActionResult Index(ContentModel model)
        {
            return base.Index(_documentService.GetDocumentListModel(model.Content));
        }
    }
}