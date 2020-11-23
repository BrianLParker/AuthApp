namespace AuthApp.Server.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserUpdateModel
    {
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTimeOffset? DateOfBirth { get; set; }

        [Display(Name = "Age Verified")]
        public bool DateOfBirthVerified { get; set; }

        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Display name")]
        public string DisplayName { get; set; }
    }

}
