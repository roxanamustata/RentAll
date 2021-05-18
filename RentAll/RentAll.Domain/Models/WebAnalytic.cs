using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Domain.Models
{
    public class WebAnalytic
    {
        public int Id { get; set; }
        //public DateTime? CreatedOn { get; set; }
        public string RequestURL { get; set; }
        public string RequestIPAdress { get; set; }
        public bool? IsRequestAuthenticated { get; set; }
        //public byte? ContentLength { get; set; }


        //public string BrowserType { get; set; }
        //public string BrowserName { get; set; }

        ////combination of Major and Minor version
        //public string BrowserVersion { get; set; }


    }
}
