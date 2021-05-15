using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.Poco;
using Sss.Mutobo.Poco;


namespace Sss.GvErlenacker.Models.ConfigModels
{
    public class SeoConfig
    {

        public Image Logo { get; set; }

		public string MetaDescription
		{
			get;
			set;
		}

		public string MetaKeywords
		{
			get;
			set;
		}
	}
}
