using System.Web.Mvc;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Services;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Sss.GvErlenacker.Controllers.Pages
{

    public class EventController : RenderMvcController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: Event
        public override ActionResult Index(ContentModel model)
        {
            return base.Index(_eventService.GetEventDetail(model.Content));
        }
    }
}