using Sss.Mutobo.Poco;

namespace Sss.Mutobo.Interfaces.Services
{
    public interface INewsLetterService
    {
        bool IsAlreadyRegistered(string email);
        void Subscribe(NewsletterUser user);
        void Unsubscribe(string email);
    }
}