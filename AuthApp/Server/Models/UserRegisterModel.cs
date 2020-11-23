namespace AuthApp.Server.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserRegisterModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTimeOffset? DateOfBirth { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Display name")]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }

}
