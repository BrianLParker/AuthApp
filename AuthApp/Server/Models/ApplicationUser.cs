namespace AuthApp.Server.Models
{
    using System;
    using System.Collections.Generic;
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

        [StringLength(450)]
        public string ManagerUserId { get; set; }

        [ForeignKey(nameof(ManagerUserId))]
        public ApplicationUser Manager { get; set; }

        [InverseProperty(nameof(Manager))]
        public IEnumerable<ApplicationUser> Subordinates { get; set; }
    }

}
