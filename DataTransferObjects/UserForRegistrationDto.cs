using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyPowerApiNew.DataTransferObjects
{
    public class UserForRegistrationDto
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


        public string PhoneNumber { get; set; }

        public ICollection<string> Roles { get; set; }


    }
}
