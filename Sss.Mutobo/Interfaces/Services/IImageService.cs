using System.Collections.Generic;
using Sss.Mutobo.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace Sss.Mutobo.Interfaces.Services
{
    public interface IImageService
    {
        Image GetImage(int id);
        Image GetImage(IPublishedContent img, int? width = null, int? height = null, ImageCropMode imageCropMode = ImageCropMode.Crop);
        IEnumerable<Image> GetImages(IEnumerable<int> ids);
        IEnumerable<Image> GetImages(IEnumerable<IPublishedContent> mediaNodes, int? width = null, int? height = null);

    }
}