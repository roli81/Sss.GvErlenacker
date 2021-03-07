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
    public class EventListController : RenderMvcController
    {
        private readonly IEventService _eventService;

        public EventListController(IEventService eventService)
        {
            _eventService = eventService;
        }


        // GET: EventList
        public override ActionResult Index(ContentModel model)
        {
            return base.Index(_eventService.GetEventPageModel(model.Content));
        }
    }
}