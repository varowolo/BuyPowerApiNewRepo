using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyPowerApiNew.DataTransferObjects
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "RequestId is Required")]
        [JsonProperty("RequestId")]
        public string RequestId { get; set; }
       

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; set; }

       

    }
}
