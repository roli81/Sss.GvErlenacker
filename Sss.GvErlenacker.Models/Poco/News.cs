using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Models.Poco
{
    public class News
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public bool ShowOnStartPage { get; set; }
        public string Abstract { get; set; }
        public Image EMotionImage { get; set; }
    }
}
