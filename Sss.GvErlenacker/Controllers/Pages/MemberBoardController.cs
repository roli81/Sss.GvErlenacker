using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sss.GvErlenacker.Services;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{
    public class MemberBoardController : RenderMvcController
    {
        private readonly IMemberBoardService _memberBoardService;

        public MemberBoardController(IMemberBoardService memberBoardService)
        {
            _memberBoardService = memberBoardService;
        }


        // GET: MemberBoard
        public override ActionResult Index(ContentModel model)
        {
            return base.Index(_memberBoardService.GetMemberBoard(model.Content));
        }
    }
}