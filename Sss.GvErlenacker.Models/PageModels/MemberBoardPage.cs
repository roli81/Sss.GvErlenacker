using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.DataModels;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Models.PageModels
{
    public class MemberBoardPage : BasePage
    {
        public IEnumerable<BoardMember> Members { get; set; }


        public MemberBoardPage(IPublishedContent content) : base(content)
        {
        }
    }
}
