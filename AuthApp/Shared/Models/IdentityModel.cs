namespace AuthApp.Shared.Models
{
    using System;
    using System.Collections.Generic;

    public class IdentityModel
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public bool DateOfBirthConfirmed { get; set; }
        public IReadOnlyList<string> Roles { get; set; }
    }
}
