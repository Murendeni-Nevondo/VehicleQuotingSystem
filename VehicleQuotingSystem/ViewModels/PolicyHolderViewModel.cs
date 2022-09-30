using System.ComponentModel.DataAnnotations;
using VehicleQuotingSystem.Models;

namespace VehicleQuotingSystem.ViewModels
{
    public class PolicyHolderViewModel
    {
        public int PolicyHolderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClientCode { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<PolicyHolder> policyHolders { get; set; } = new List<PolicyHolder>();
        public List<Quote> Quotes { get; set; } = new List<Quote>();

    }
}
