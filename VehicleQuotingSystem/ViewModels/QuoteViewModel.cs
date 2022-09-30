using VehicleQuotingSystem.Models;

namespace VehicleQuotingSystem.ViewModels
{
    public class QuoteViewModel
    {
        public int QuoteId { get; set; }
        public decimal SumInsured { get; set; }
        public decimal Rate { get; set; }
        public string VehicleIds { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<VehicleQuote> VehicleQuotes { get; set; }
        public PolicyHolder PolicyHolder { get; set; }
    }
}
