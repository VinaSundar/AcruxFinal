using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHealth.Models
{
    public class LoginViewModel
    {
        public string BusinessName { get; set; }
        public string BusinessId { get; set; }
        public string CountryOfIncorporation { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
