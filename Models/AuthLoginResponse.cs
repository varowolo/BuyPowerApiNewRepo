using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyPowerApiNew.Models
{
    public class AuthLoginResponse
    {
        public string message { get; set; }
        public string name { get; set; }
        public bool authenticated { get; set; }
    }
}
