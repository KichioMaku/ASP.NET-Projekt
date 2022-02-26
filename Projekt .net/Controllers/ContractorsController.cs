using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_.net.Database;
using Projekt_.net.Models;
using Projekt_.net.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Controllers
{
    [Authorize]
    public class ContractorsController : Controller
    {
        private readonly IContractorsService _contractorService;

        public ContractorsController(IContractorsService contractorService)
        {
            _contractorService = contractorService;
        }

        public async Task<IActionResult> Index(string name)
        {
            var contractors = await _contractorService.GetAll(name);
            return View(contractors);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContractorsModel contractor)
        {
            if (!ModelState.IsValid) return View(contractor);

            await _contractorService.Add(contractor);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var contractor = await _contractorService.GetById(id);
            if (contractor == null) return View("Error");
            var newContractor = new ContractorsModel()
            {
                Id = contractor.Id,
                ContractorName = contractor.ContractorName,
                EmailAddress = contractor.EmailAddress,
                Address = contractor.Address,
                PhoneNumber = contractor.PhoneNumber,
                NIP = contractor.NIP
            };
            return View(newContractor);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ContractorsModel contractor)
        {
            if (id != contractor.Id) return View("Error");
            if (!ModelState.IsValid) return View(contractor);
            await _contractorService.Update(contractor);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteGet(int id)
        {
            var contractor = await _contractorService.GetById(id);
            if (contractor == null) return View("Error");
            return View(contractor);
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var contractor = await _contractorService.GetById(id);
            if (contractor == null) return View("Error");
            await _contractorService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
