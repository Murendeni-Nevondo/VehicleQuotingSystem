using System.ComponentModel.DataAnnotations;

namespace VehicleQuotingSystem.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Int16 Year { get; set; }
        public decimal RetailValue { get; set; }
        public List<VehicleQuote> VehicleQuotes { get; set; }
    }
}
