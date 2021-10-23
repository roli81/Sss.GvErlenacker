using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Models.Poco
{
    public class ContactFormViewModel
    {
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string FuSb { get; set; }
        public Guid Key { get; set; }
        public string CaptchaCode { get; set; }


    }
}
