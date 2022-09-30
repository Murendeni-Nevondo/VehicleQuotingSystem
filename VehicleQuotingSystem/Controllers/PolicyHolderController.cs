using Microsoft.AspNetCore.Mvc;
using VehicleQuotingSystem.ViewModels;
using VehicleQuotingSystem.Data;
using VehicleQuotingSystem.Models;
//using System.Data.Entity;

namespace VehicleQuotingSystem.Controllers
{
    public class PolicyHolderController : Controller
    {
        private readonly VehicleQuotingSystemContext _context;
        public PolicyHolderController(VehicleQuotingSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var _policyHolders = _context.PolicyHolders.ToList();
            var policyHolderViewModel = new PolicyHolderViewModel()
            {
                policyHolders = _policyHolders
            };
            return View(policyHolderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddPolicyHolder(PolicyHolderViewModel addPolicyHolderViewModel)
        {
            var policyHolder = new PolicyHolder()
            {
                FirstName = addPolicyHolderViewModel.FirstName,
                LastName = addPolicyHolderViewModel.LastName,
                ClientCode = addPolicyHolderViewModel.FirstName.ToUpper() + "" + addPolicyHolderViewModel.LastName[0],
                Email = addPolicyHolderViewModel.Email,
                DateOfBirth = addPolicyHolderViewModel.DateOfBirth,
            };

            await _context.PolicyHolders.AddAsync(policyHolder);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var policyHolder = _context.PolicyHolders.FirstOrDefault(p => p.PolicyHolderId == Id);
            var quotes = _context.Quotes.Where(p => p.PolicyHolderId == Id).ToList();

            if (policyHolder == null)
                return RedirectToAction("Index");

            var policyHolderViewModel = new PolicyHolderViewModel()
            {
                PolicyHolderId = policyHolder.PolicyHolderId,
                FirstName = policyHolder.FirstName,
                LastName = policyHolder.LastName,
                Email = policyHolder.Email,
                DateOfBirth = policyHolder.DateOfBirth,
                ClientCode = policyHolder.ClientCode,
                Quotes = quotes
            };
            return View(policyHolderViewModel);
        }
    }
}
