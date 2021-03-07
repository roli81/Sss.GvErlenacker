using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Models.Poco
{
    public class Link
    {
        public string Text { get; set; }
        public string Href { get; set; }
        public bool Active { get; set; }

        public bool OpenInNewWindow { get; set; }
    }
}
