using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Sss.GvErlenacker.Services.Impl
{
    public class MemberBoardService : BaseService, IMemberBoardService
    {
        private readonly IImageService _imageService;

        public MemberBoardService(IImageService imageService)
        {
            _imageService = imageService;
        }


        public MemberBoardPage GetMemberBoard(IPublishedContent content)
        {
            var members = content.Value<IEnumerable<IPublishedElement>>("boardMembers")
                .Select(m => new BoardMember(m)
                {
                    Image = m.HasValue("image") ? _imageService.GetImage(m.Value<IPublishedContent>("image"), height: 200, width: 200) : null,
                    
                }).ToList();

            return new MemberBoardPage(content)
            {
                EmotionImage = content.HasProperty("emotionImage") && content.HasValue("emotionImage")
                    ? _imageService.GetImage(content.Value<IPublishedContent>("emotionImage"))
                    : null,
                Members = members
            };
        }
    }
}
