using Sss.GvErlenacker.Models.ConfigModels;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Services
{
    public interface IConfigService
    {
        HeaderConfig GetHeaderConfig(IPublishedContent currentPage);
        FooterConfig GetFooterConfig();
        SeoConfig GetSeoConfig();

        EMailConfig GetEMailConfig(int id);

    }
}