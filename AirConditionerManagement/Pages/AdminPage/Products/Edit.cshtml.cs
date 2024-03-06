using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirConditionerBussinessObjects.Models;
using AirConditionerService.Interface;
using AirConditionerService.ViewModel;

namespace AirConditionerManagement.Pages.AdminPage.Products
{
    public class EditModel : PageModel
    {
        private readonly IAirConditionerService _airConditionerService;

        public EditModel(IAirConditionerService airConditionerService)
        {
            _airConditionerService = airConditionerService;
            AirConditionerVM = new EditAirConditionerViewModel();
        }

        
        [BindProperty]
        public EditAirConditionerViewModel AirConditionerVM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var airconditioner = await _airConditionerService.GetAirConditionerByIdAsync(id);
                if (airconditioner == null)
                {
                    return NotFound();
                }

                // Gán dữ liệu của airconditioner vào AirConditionerVM

                AirConditionerVM.AirConditionerName = airconditioner.AirConditionerName;
                AirConditionerVM.Warranty = airconditioner.Warranty;
                AirConditionerVM.SoundPressureLevel = airconditioner.SoundPressureLevel;
                AirConditionerVM.URL = airconditioner.Image;
                AirConditionerVM.FeatureFunction = airconditioner.FeatureFunction;
                AirConditionerVM.Quantity = airconditioner.Quantity;
                AirConditionerVM.DollarPrice = airconditioner.DollarPrice;
                AirConditionerVM.SupplierId = airconditioner.SupplierId;
                TempData["AirConditionerId"] = airconditioner.AirConditionerId;

                var supplierCompanies = _airConditionerService.GetSupplierCompanies();
                ViewData["SupplierId"] = new SelectList(supplierCompanies, "SupplierId", "SupplierName");
                return Page();
            }
            return RedirectToPage("/Login");
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var airConditionerId = TempData["AirConditionerId"] as int?;
            if (airConditionerId == null)
            {
                return BadRequest("Invalid AirConditionerId");
            }

            var check = AirConditionerVM.AirConditionerId;

            try
            {
                await _airConditionerService.EditAirConditioner(airConditionerId.Value, AirConditionerVM);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_airConditionerService.GetAllAirConditioners().Any(e => e.AirConditionerId == airConditionerId.Value))
                {
                    return NotFound();
                }
                
            }

            return RedirectToPage("./Index");
        }

}
    }

