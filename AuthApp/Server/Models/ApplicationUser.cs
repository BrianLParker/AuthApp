namespace AuthApp.Server.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [MaxLength(200)]
        public string DisplayName { get; set; }

        [PersonalData]
        [Column("DoB")]
        public DateTimeOffset? DateOfBirth { get; set; }

        [PersonalData]
        [Column("DoBVerified")]
        public bool DateOfBirthVerified { get; set; }
    }

}
