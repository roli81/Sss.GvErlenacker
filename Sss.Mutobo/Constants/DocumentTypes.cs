using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Mutobo.Constants
{
    public static class DocumentTypes
    {


        public static class NewsletterModule
        {
            public const string Alias = "newsletterModule";

            public static class Fields
            {
                public const string Subscribers = "subscribers";
            }


        }

        public static class CarouselModule
        {
            public const string Alias = "carouselModule";

            public static class Fields
            {
                public const string Images = "images";
            }


        }


        public static class FlyerTeaserModule
        {
            public const string Alias = "flyerTeaser";

            public static class Fields
            {
                public const string Image = "image";
                public const string Text = "text";
                public const string TargetLink = "targetLink";
            }


        }

    }
}
