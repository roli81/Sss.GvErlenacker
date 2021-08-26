using Sss.Mutobo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Newsletter.Interfaces
{
    public interface INewsletterService
    {
        void InitNewsletterNews();

        void SendNewsLetter();

        DateTime GetLastDispatchRun();


    }
}
