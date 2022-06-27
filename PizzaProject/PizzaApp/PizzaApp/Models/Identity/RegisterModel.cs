using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.Models.Identity
{
    public class RegisterModel
    {
        [Required] 
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage = "Passwords must be the same")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}