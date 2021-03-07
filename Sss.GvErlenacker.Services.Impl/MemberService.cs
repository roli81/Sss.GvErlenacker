using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Sss.GvErlenacker.Models.Enums;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace Sss.GvErlenacker.Services.Impl
{
    public class MemberService : BaseService, IMemberService
    {
        private readonly IContentService _contentService;


        public MemberService(IContentService contentService)
        {

            _contentService = contentService;
        }

        public void RegisterMember(MemberFormModel formData, IMedia mediaItem)
        {
            var documentType =
                formData.SponsorType == ESponsorType.Business || formData.SponsorType == ESponsorType.Link ? "businessSponsor" : "sponsor";
            var content = _contentService.CreateContent(formData.SponsorType == ESponsorType.Business || formData.SponsorType == ESponsorType.Link ? formData.Company : $"{formData.Name} {formData.FirstName}", _contentService.GetById(1296).GetUdi(), documentType, 0);

            if (formData.SponsorType == ESponsorType.Business || formData.SponsorType == ESponsorType.Link)
            {
                content.SetValue("factoryName", formData.Company);
                content.SetValue("website", formData.Website);

                if (mediaItem != null)
                {
                    content.SetValue("logo", mediaItem.GetUdi().ToString());
                }
            }

            content.SetValue("surname", formData.Name);
            content.SetValue("firstname", formData.FirstName);
            content.SetValue("street", formData.Street);
            content.SetValue("number", formData.Number);
            content.SetValue("zipCode", formData.Zip);
            content.SetValue("city", formData.City);
            content.SetValue("email", formData.Email);

            _contentService.Save(content);
        }

    }
}
