using System.Web;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models;

namespace Sss.GvErlenacker.Services
{
    public interface IMemberService
    {
        void RegisterMember(MemberFormModel formData, IMedia mediaItem);

    }
}