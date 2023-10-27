﻿using System.ComponentModel.DataAnnotations;

namespace Database.Authentication.SignUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set;}

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set;}

        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set;}
    }
}
