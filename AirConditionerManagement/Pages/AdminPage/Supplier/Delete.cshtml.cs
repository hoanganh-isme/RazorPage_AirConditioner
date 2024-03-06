using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirConditionerBussinessObjects.Models;
using AirConditionerService.Interface;

namespace AirConditionerManagement.Pages.AdminPage.Supplier
{
    public class DeleteModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public DeleteModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [BindProperty]
      public SupplierCompany SupplierCompany { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                if (id == null || _supplierService.GetAllSuppliers() == null)
                {
                    return NotFound();
                }

                var suppliercompany = _supplierService.GetSupplierById(id);

                if (suppliercompany == null)
                {
                    return NotFound();
                }
                else
                {
                    SupplierCompany = suppliercompany;
                }
                return Page();
            }
            return RedirectToPage("/Login");
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _supplierService.GetAllSuppliers() == null)
            {
                return NotFound();
            }
            var suppliercompany = _supplierService.GetSupplierById(id);

            if (suppliercompany != null)
            {
                SupplierCompany = suppliercompany;
                _supplierService.DeleteSupplier(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
