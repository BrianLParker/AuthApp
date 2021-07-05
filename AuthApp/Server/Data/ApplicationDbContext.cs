namespace AuthApp.Server.Data
{
    using AuthApp.Server.Models;
    using IdentityServer4.EntityFramework.Options;
    using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserCustomer> UserCustomers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserCustomer>().HasKey(nameof(UserCustomer.UserId), nameof(UserCustomer.CustomerId));
            base.OnModelCreating(builder);
        }

    }
}
