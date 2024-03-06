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

namespace AirConditionerManagement.Pages.AdminPage.Supplier
{
    public class EditModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public EditModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [BindProperty]
        public SupplierCompany SupplierCompany { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _supplierService.GetAllSuppliers() == null)
            {
                return NotFound();
            }

            var suppliercompany =  _supplierService.GetSupplierById(id);
            if (suppliercompany == null)
            {
                return NotFound();
            }
            SupplierCompany = suppliercompany;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }


                try
                {
                    _supplierService.UpdateSupplier(SupplierCompany);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierCompanyExists(SupplierCompany.SupplierId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToPage("./Index");
            }
            return RedirectToPage("/Login");
        }

        private bool SupplierCompanyExists(string id)
        {
          return (_supplierService.GetAllSuppliers()?.Any(e => e.SupplierId == id)).GetValueOrDefault();
        }
    }
}
