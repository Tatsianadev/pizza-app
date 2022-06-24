using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaApp.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Display(Name="UserName")]
        [Required(ErrorMessage = "Enter your Name")]
        public string Name { get; set; }

        [Display(Name="Password")]
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [ Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Enter Login")]
        public string Login { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter delivery address ")]
        public string Address { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Enter phone number ")]
        public string Phone { get; set; }
        public string Email { get; set; }
    }

   


}