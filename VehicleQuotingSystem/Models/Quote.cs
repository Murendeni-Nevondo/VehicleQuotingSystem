using System.ComponentModel.DataAnnotations;

namespace VehicleQuotingSystem.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }
        public string QuoteRef { get; set; }
        public DateTime DateCreated { get; set; }

        //Navigation properties
        public int PolicyHolderId { get; set; }
        public PolicyHolder PolicyHolder { get; set; }
        public List<VehicleQuote> VehicleQuotes { get; set; }
    }
}
