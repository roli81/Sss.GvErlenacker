using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Models.Poco
{
    public class NavItem
    {
        public bool HideFromNavigation { get; set; }
        public bool Clickable { get; set; }
        public Link Link { get; set; }
        public IEnumerable<NavItem> Children { get; set; }
    }
}
