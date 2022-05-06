using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BuyPowerApiNew.Models
{
    public class BuyPowerAddressLookup
    {
           //public string RequestId { get; set; }
           //[JsonProperty("body")]

        public string phone { get; set; }

        public string people { get; set; }

        public string address { get; set; }


    }

    public class AddressLookup
    {
        [Required(ErrorMessage = "RequestID is required")]
        public string RequestId { get; set; }
       
        [Required(ErrorMessage = "Client is required")]
        public string Client { get; set; }
        
        public string phone { get; set; }

        [Required(ErrorMessage = "Platform is required")]
        public string platform { get; set; }
        // [Required(ErrorMessage = "Channel is required")]
        public string channel { get; set; }
       
    }

    public class FacilityLookup
    {
        [Required(ErrorMessage = "RequestID is required")]
        public string RequestId { get; set; }

        [Required(ErrorMessage = "Client is required")]
        public string Client { get; set; }
        
        public string reference { get; set; }

        [Required(ErrorMessage = "Platform is required")]
        public string platform { get; set; }
        public string channel { get; set; }
       
    }

    public class Balance
    {
        [Required(ErrorMessage = "RequestID is required")]
        public string RequestId { get; set; }

        [Required(ErrorMessage = "Client is required")]
        public string Client { get; set; }

        [Required(ErrorMessage = "Platform is required")]
        public string platform { get; set; }
        public string channel { get; set; }

       
    }
}
