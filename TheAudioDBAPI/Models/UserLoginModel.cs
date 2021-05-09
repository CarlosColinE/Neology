using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheAudioDBAPI.Models
{   
    public class UserLoginModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string Error { get; set; }
        public string RolUser { get; set; }
        public string Token { get; set; }
    }
}