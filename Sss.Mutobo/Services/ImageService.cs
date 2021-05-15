using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Sss.Mutobo.Interfaces.Services;
using Sss.Mutobo.Poco;

using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Composing;

namespace Sss.Mutobo.Services
{
    public class ImageService :  IImageService
    {

        public Image GetImage(IPublishedContent img, int? width = null, int? height = null, ImageCropMode imageCropMode = ImageCropMode.Crop)
        {

            var media = Current.UmbracoHelper.Media(img.Id);

            if (media == null)
                throw new NodeNotFoundException($"node width id {img.Id} not found!");

           
            return new Image()
            {
                LargeUrl = media.GetCropUrl(width, height, imageCropMode: imageCropMode),
                SmallUrl = media.GetCropUrl(width / 2, height, imageCropMode: imageCropMode),
                Alt = media.Name
            };
        }

        public Image GetImage(int id)
        {
            if (id == 0)
                return null;


            var media = Current.UmbracoHelper.Media(id);

            if (media == null)
                throw new NodeNotFoundException($"node width id {id} not found!");


            return new Image()
            {
                LargeUrl = media.GetCropUrl(width: 1050),
                SmallUrl = media.GetCropUrl(width: 400),
                Alt = media.Name
            };
        }

        public IEnumerable<Image> GetImages(IEnumerable<int> ids)
        {
            var images = new List<Image>();


            foreach (var id in images)
            {
                var media = Current.UmbracoHelper.Media(id);

                if (media == null)
                    throw new NodeNotFoundException($"media with id {id} not found");

                images.Add(new Image()
                {
                    SmallUrl = media.GetCropUrl(width: 400),
                    LargeUrl = media.GetCropUrl(width: 1050),
                    Alt = media.Name
                });
            }

            return images;
        }

        public IEnumerable<Image> GetImages(IEnumerable<IPublishedContent> mediaNodes, int? width = null, int? height = null)
        {
            var smallUrl = string.Empty;
            return mediaNodes.Select(mn => new Image() { LargeUrl = mn.GetCropUrl(width: width, height: height), SmallUrl = mn.GetCropUrl(width: width/2, height: height) });
        }
    }
}
