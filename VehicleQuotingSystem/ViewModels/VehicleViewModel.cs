using System.ComponentModel.DataAnnotations;
using VehicleQuotingSystem.Models;

namespace VehicleQuotingSystem.ViewModels
{
    public class VehicleViewModel
    {
        [Required(ErrorMessage = "Vehicle Make is required")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Vehicle Model is required")]
        public string Model { get; set; }

        [Range(1994, 2021, ErrorMessage = "Year should be between 2000 and 2021")]
        public Int16 Year { get; set; }
        public decimal RetailValue { get; set; }
        public List<Vehicle> vehicles { get; set; } = new List<Vehicle>();
    }
}
