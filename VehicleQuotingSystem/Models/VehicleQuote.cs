namespace VehicleQuotingSystem.Models
{
    public class VehicleQuote
    {
        public int Id { get; set; }
        public decimal SumInsured { get; set; }
        public decimal Rate { get; set; }
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public int QuoteId { get; set; }
        public Quote? Quote { get; set; }
    }
}
