using System.Collections.Generic;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.PageModels;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Services
{
    public interface ISponsorService
    {
        SponsorPage GetSponsorListModel();
        BusinessSponsor GetPremiumSponsor();
        IEnumerable<Sponsor> GetSponsors();


    }
}