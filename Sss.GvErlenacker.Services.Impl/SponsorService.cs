using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.PageModels;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Sss.GvErlenacker.Services.Impl
{
    public class SponsorService : BaseService, ISponsorService
    {
        private readonly  IImageService _imageService;

        public SponsorService(IImageService imageService)
        {
            _imageService = imageService;
        }

        public BusinessSponsor GetPremiumSponsor()
        {
            var sponsorPage = CurrentHelper
                .ContentAtRoot()
                .FirstOrDefault(c => c.ContentType.Alias == "homePage")
                .Children().FirstOrDefault(c => c.ContentType.Alias == "sponsorPage");

            return sponsorPage.Children
                .Where(c => c.ContentType.Alias == "businessSponsor").Select(c => new BusinessSponsor(c)
                {
                    Logo = c.HasValue("logo") ? _imageService.GetImage(c.Value<IPublishedContent>("logo"), 400) : null,
                }).FirstOrDefault(c => c.IsPremiumSponsor);
        }

        public IEnumerable<Sponsor> GetSponsors()
        {
            var sponsorList = new List<Sponsor>();

            var sponsors = CurrentHelper
                .ContentAtRoot()
                .FirstOrDefault(c => c.ContentType.Alias == "homePage")
                .Children().FirstOrDefault(c => c.ContentType.Alias == "sponsorPage").Children();


            foreach (var sponsor in sponsors)
            {
                if (sponsor.ContentType.Alias == "sponsor")
                {
                    sponsorList.Add(new Sponsor(sponsor));
                }
                else if (sponsor.ContentType.Alias == "businessSponsor")
                {
                    sponsorList.Add(new BusinessSponsor(sponsor));
                }
            }

            return sponsorList;
        }

        public SponsorPage GetSponsorListModel()
        {

            var currentPage = Umbraco.Web.Composing.Current.UmbracoHelper.AssignedContentItem;

            var businessSponsors = currentPage.Children.Where(c => c.ContentType.Alias == "businessSponsor").Select(c => new BusinessSponsor(c)
            {
                Logo = c.HasValue("logo") ? _imageService.GetImage(c.Value<IPublishedContent>("logo"), 400) : null,
            });

            var enumerable = businessSponsors as BusinessSponsor[] ?? businessSponsors.ToArray();
            var business = enumerable.Where(c => !c.IsPremiumSponsor).ToList();
            var randomOrdered = new List<BusinessSponsor>();


            var indicies = new List<int>();

            var usedIdicies = new List<int>();

            foreach (var t in business)
            {
                do
                {
                    var rnd = new Random();
                    var index = rnd.Next(business.Count);
                    if (!usedIdicies.Contains(index))
                    {
                        usedIdicies.Add(index);
                        randomOrdered.Add(business[index]);
                    }

                } while (usedIdicies.Count != business.Count);
            }








            return  new SponsorPage(currentPage)
            {
               
                PremiumSponsor = enumerable.FirstOrDefault(c => c.IsPremiumSponsor),
                BusinessSponsors = randomOrdered,
                Sponsors = currentPage.Children.Where(c => c.ContentType.Alias == "sponsor").Select(c => new Sponsor(c)).OrderBy(s => s.Surname).ThenBy(s => s.Firstname),
                EmotionImage = _imageService.GetImage(currentPage.Value<IPublishedContent>("emotionImage"))

            }; ;
        }

    }
}
