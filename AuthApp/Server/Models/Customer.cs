using System.ComponentModel.DataAnnotations;

namespace AuthApp.Server.Models
{
    public class Customer
    {
        [Key]
        [MaxLength(450)]
        public string Id { get; set; }
    }
}
