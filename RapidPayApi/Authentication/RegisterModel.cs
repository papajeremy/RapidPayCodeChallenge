﻿using System.ComponentModel.DataAnnotations;

namespace RapidPayApi.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;

        [Required( ErrorMessage = "Email address is required" )]
        [EmailAddress( ErrorMessage = "Email address is not valid" )]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, ErrorMessage = "Password must be at least 3 characters long", MinimumLength = 3)]
        public string Password { get; set; } = string.Empty;
    }
}
