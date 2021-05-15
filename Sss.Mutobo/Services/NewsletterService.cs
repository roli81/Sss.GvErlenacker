using System;
using Sss.Mutobo.Interfaces.Services;
using Sss.Mutobo.Poco;

namespace Sss.Mutobo.Services
{
    public class NewsletterService : INewsLetterService
    {
        public bool IsAlreadyRegistered(string email)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(NewsletterUser user)
        {
            throw new NotImplementedException();
        }



        public void Unsubscribe(string email)
        {
            throw new NotImplementedException();
        }
    }
}
