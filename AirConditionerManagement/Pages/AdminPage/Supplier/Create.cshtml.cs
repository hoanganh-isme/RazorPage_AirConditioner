using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AirConditionerBussinessObjects.Models;
using AirConditionerService.Interface;

namespace AirConditionerManagement.Pages.AdminPage.Supplier
{
    public class CreateModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public CreateModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                return Page();
            }
            return RedirectToPage("/Login");
        }

        [BindProperty]
        public SupplierCompany SupplierCompany { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _supplierService.GetAllSuppliers() == null || SupplierCompany == null)
            {
                return Page();
            }

            _supplierService.GetAllSuppliers().Add(SupplierCompany);

            return RedirectToPage("./Index");
        }
    }
}
