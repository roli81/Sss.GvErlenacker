using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.Poco;

namespace Sss.GvErlenacker.Services
{
    public interface IMailService
    {
        void SendConfirmMail(MemberFormModel model);
        void SendInfoMail(MemberFormModel model);
        void SendContactMail(ContactFormViewModel model);

        void SendMessageReceivedMail(ContactFormViewModel model);
    }
}