using System.Runtime.CompilerServices;
using Sss.GvErlenacker.Models.PageModels;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Services
{


    public interface IEventService
    {
        Event GetEventDetail(IPublishedContent content);
        EventList GetEventPageModel(IPublishedContent content);
    }
}