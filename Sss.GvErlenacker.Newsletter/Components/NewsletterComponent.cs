
using Sss.GvErlenacker.Newsletter.Interfaces;
using Sss.GvErlenacker.Newsletter.Services;
using Sss.GvErlenacker.Newsletter.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web.Scheduling;

namespace Sss.GvErlenacker.Newsletter.Components
{
    public class NewsletterComponent : IComponent
    {
        private readonly INewsletterService _newsletterService;
        private IProfilingLogger _logger;
        private IRuntimeState _runtime;
   
        private BackgroundTaskRunner<IBackgroundTask> _newsletterSendRunner;

        public NewsletterComponent(INewsletterService newsletterService, IProfilingLogger logger, IRuntimeState runtime)
        {
            _newsletterService = newsletterService;
            _logger = logger;
            _runtime = runtime;
            _newsletterSendRunner = new BackgroundTaskRunner<IBackgroundTask>("NewsletterSend",_logger);

        }

        public void Initialize()
        {

            int delayBeforeWeStart = 0; // 0
                                        //int howOftenWeRepeat = 86400000; //24h
            int howOftenWeRepeat = 1000; //24h

            _newsletterService.InitNewsletterNews();

            var task = new NewsletterSender(_newsletterSendRunner, delayBeforeWeStart, howOftenWeRepeat, _runtime, _logger, _newsletterService);

            //As soon as we add our task to the runner it will start to run (after its delay period)
            _newsletterSendRunner.TryAdd(task);


        }

        public void Terminate()
        {
       

            
        }



    }
}
