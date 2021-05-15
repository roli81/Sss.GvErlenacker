using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.Mutobo.Poco;

namespace Sss.GvErlenacker.Models.Poco
{
    public class Tile
    {
        public string Title { get; set; }
        public string Abstract { get; set; }

        public Image Image { get; set; }
        public Link Link { get; set; }
        public bool NotClickable { get; set; }
        public bool HideFromNavigation { get; set; }
    }
}
