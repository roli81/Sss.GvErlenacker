using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Sss.GvErlenacker.Services.Impl
{
    public class ImageService : BaseService, IImageService
    {

        public Image GetImage(IPublishedContent img, int? width = null, int? height = null, ImageCropMode imageCropMode = ImageCropMode.Crop)
        {

            var media = CurrentHelper.Media(img.Id);

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


            var media = CurrentHelper.Media(id);

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
                var media = CurrentHelper.Media(id);

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
