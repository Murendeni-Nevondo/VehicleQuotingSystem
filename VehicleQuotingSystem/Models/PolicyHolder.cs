using System.ComponentModel.DataAnnotations;

namespace VehicleQuotingSystem.Models
{
    public class PolicyHolder
    {
        [Key]
        public int PolicyHolderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClientCode { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
