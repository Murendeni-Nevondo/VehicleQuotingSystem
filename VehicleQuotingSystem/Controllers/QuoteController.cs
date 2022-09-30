using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleQuotingSystem.Data;
using VehicleQuotingSystem.Models;
using VehicleQuotingSystem.ViewModels;

namespace VehicleQuotingSystem.Controllers
{
    public class QuoteController : Controller
    {
        private readonly VehicleQuotingSystemContext _context;
        public QuoteController(VehicleQuotingSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchQuoteViewModel()
            {
                Quotes = new List<QuoteVm>()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ViewQuote(int Id)
        {
            //policy holder
            var _policyHolder = new PolicyHolder();
            var policyHolder = await _context.VehicleQuotes.Include(p => p.Quote.PolicyHolder).Where(q => q.Quote.QuoteId == Id).FirstOrDefaultAsync();

            if (policyHolder != null)
                _policyHolder = policyHolder.Quote.PolicyHolder;

            //drop down select vehicles
            var vehicles = _context.Vehicles.ToList();

            //quote vehicles
            var quoteVehicles = await _context.VehicleQuotes.Include(v => v.Vehicle).Include(q => q.Quote).Where(q => q.QuoteId == Id).ToListAsync();

            var quoteViewModel = new QuoteViewModel()
            {
                Vehicles = vehicles,
                QuoteId = Id,
                VehicleQuotes = quoteVehicles,
                PolicyHolder = _policyHolder
            };
            return View(quoteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> NewQuote(PolicyHolderViewModel policyHolderViewModel)
        {
            var quote = new Quote()
            {
                DateCreated = DateTime.Now,
                PolicyHolderId = policyHolderViewModel.PolicyHolderId,
                QuoteRef = ""
            };

            await _context.Quotes.AddAsync(quote);
            await _context.SaveChangesAsync();

            quote.QuoteRef = "Q0000" + quote.QuoteId.ToString();
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewQuote");
        }

        [HttpPost]
        public async Task<IActionResult> QuoteSearch(SearchQuoteViewModel searchQuoteViewModel)
        {
            var quotes = await _context.VehicleQuotes.Where(v => v.Vehicle.Model == searchQuoteViewModel.CarModel || v.Vehicle.Make == searchQuoteViewModel.CarMake || v.Vehicle.Year == searchQuoteViewModel.Year).Select(q => new QuoteVm()
            {
                QuoteId = q.QuoteId,
                QuoteRef = q.Quote.QuoteRef,
                DateCreated = q.Quote.DateCreated,
                PolicyHolder = q.Quote.PolicyHolder.FirstName+" "+q.Quote.PolicyHolder.LastName
            }).ToListAsync();

            var viewModel = new SearchQuoteViewModel()
            {
                Quotes = quotes,
            };

            return View("Index", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicleToQuote(QuoteViewModel quoteViewModel)
        {
            var vehicleIds = quoteViewModel.VehicleIds.Split(",").ToList();

            foreach(var vehicleId in vehicleIds)
            {
                var vehicle = await _context.VehicleQuotes.SingleOrDefaultAsync(v => v.VehicleId == int.Parse(vehicleId) && v.QuoteId == quoteViewModel.QuoteId);

                if(vehicle == null)
                {
                    var vehicleQuote = new VehicleQuote()
                    {
                        VehicleId = int.Parse(vehicleId),
                        QuoteId = quoteViewModel.QuoteId,
                        Rate = quoteViewModel.Rate,
                        SumInsured = quoteViewModel.SumInsured,
                    };

                    _context.VehicleQuotes.Add(vehicleQuote);
                    _context.SaveChanges();
                }

            }

            return RedirectToAction("ViewQuote","Quote", new {id = quoteViewModel.QuoteId });
        }
    }
}
