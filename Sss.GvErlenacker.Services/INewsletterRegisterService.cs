using Sss.Mutobo.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Services
{
    public interface INewsletterRegisterService
    {
        bool IsAlreadyRegistered(string email);
        void Subscribe(NewsletterUser user);
        void Unsubscribe(string email);
    }
}
