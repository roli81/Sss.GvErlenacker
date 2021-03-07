using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Models.Poco
{
    public class Image
    {
        public string LargeUrl { get; set; }
        public string SmallUrl { get; set; }
        public string Alt { get; set; }
        public string CaptionTitle { get; set; }
        public string CaptionText { get; set; }
    }
}
