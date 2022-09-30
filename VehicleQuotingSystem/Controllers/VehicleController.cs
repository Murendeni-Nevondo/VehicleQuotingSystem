using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleQuotingSystem.Data;
using VehicleQuotingSystem.Models;
using VehicleQuotingSystem.ViewModels;

namespace VehicleQuotingSystem.Controllers
{
    public class VehicleController : Controller
    {
        private readonly Data.VehicleQuotingSystemContext _context;
        public VehicleController(Data.VehicleQuotingSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var _vehicles = _context.Vehicles.ToList();
            var vehicleViewModel = new VehicleViewModel()
            {
                vehicles = _vehicles
            };
            return View(vehicleViewModel); 
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(VehicleViewModel addVehicleViewModel)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Index");

            var vehicle = new Vehicle()
            {
                Make = addVehicleViewModel.Make,
                Model = addVehicleViewModel.Model,
                Year = addVehicleViewModel.Year,
                RetailValue = addVehicleViewModel.RetailValue
            };

            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<Vehicle> GetVehicle(int Id)
        {
            var vehicle = await _context.Vehicles.SingleOrDefaultAsync(v => v.VehicleId == Id);
            if (vehicle == null)
                return new Vehicle();
            return vehicle;
        }
    }
}
