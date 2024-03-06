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
    public class IndexModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public IndexModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IList<SupplierCompany> SupplierCompany { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                if (_supplierService.GetAllSuppliers() != null)
                {
                    SupplierCompany = _supplierService.GetAllSuppliers();
                }
                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}
