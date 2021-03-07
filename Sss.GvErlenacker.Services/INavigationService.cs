using System.Collections;
using System.Collections.Generic;
using Sss.GvErlenacker.Models.Poco;

namespace Sss.GvErlenacker.Services
{
    public interface INavigationService
    {
        IEnumerable<Tile> GetTileNavigation();
        IEnumerable<Link> GetBreadCrumbNavigation();
        IEnumerable<NavItem> GetSectionNavigation();
    }
}