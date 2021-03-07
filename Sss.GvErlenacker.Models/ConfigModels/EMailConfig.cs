using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Models.ConfigModels
{
    public class EMailConfig
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public string SalutationFemale { get; set; }
        public string SalutationMale { get; set; }
        public string SenderEmail { get; set; }
        public IEnumerable<string> ReceiverEMails { get; set; }


    }
}