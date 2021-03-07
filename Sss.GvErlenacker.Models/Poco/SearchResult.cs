using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Models.Poco
{
    public class SearchResult
    {
        public string RedirectUrl { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public Image EmotionImage { get; set; }

        public string SponsorUrl { get; set; }
    }
}
