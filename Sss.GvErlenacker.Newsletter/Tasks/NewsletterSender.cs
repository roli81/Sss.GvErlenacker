using Sss.GvErlenacker.Newsletter.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;
using Umbraco.Web.Scheduling;

namespace Sss.GvErlenacker.Newsletter.Tasks
{
    public class NewsletterSender : RecurringTaskBase
    {
        private IRuntimeState _runtime;
        private IProfilingLogger _logger;
        private INewsletterService _newsletterService;

        public NewsletterSender(IBackgroundTaskRunner<RecurringTaskBase> runner, int delayBeforeWeStart, int howOftenWeRepeat, IRuntimeState runtime, IProfilingLogger logger, INewsletterService newsletterService)
            : base(runner, delayBeforeWeStart, howOftenWeRepeat)
        {
            _runtime = runtime;
            _logger = logger;
            _newsletterService = newsletterService;
        }


        public override bool PerformRun()
        {
            Debug.WriteLine("??????????????????Newsletter prüfen????????????????????????????????");

            if (_newsletterService.GetLastDispatchRun() <= DateTime.Now.AddSeconds(-60))
            {
                _newsletterService.SendNewsLetter();
                Debug.WriteLine("!!!!!!!!!!!!Newsletter versendet!!!!!!!!!!!!!!!!!!!!!");
            }

            return true;
        }



        public override bool IsAsync => false;


    }
}
