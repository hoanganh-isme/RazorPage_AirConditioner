using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AirConditionerBussinessObjects.Models;
using AirConditionerService.Interface;
using AirConditionerService.ViewModel;

namespace AirConditionerManagement.Pages.AdminPage.Products
{
    public class CreateModel : PageModel
    {
        private readonly IAirConditionerService _airConditionerService;

        public CreateModel(IAirConditionerService airConditionerService)
        {
            _airConditionerService = airConditionerService;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                var supplierCompanies = _airConditionerService.GetSupplierCompanies();
                ViewData["SupplierId"] = new SelectList(supplierCompanies, "SupplierId", "SupplierName");

                // Khởi tạo một đối tượng AirConditioner

                return Page();
            }
            return RedirectToPage("/Login");
        }

        [BindProperty]
        public AddAirConditionerViewModel AirConditioner { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _airConditionerService.GetAllAirConditioners() == null || AirConditioner == null)
            {
                return Page();
            }

            bool addedSuccessfully = await _airConditionerService.AddAirConditioner(AirConditioner);

            if (addedSuccessfully)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                // Xử lý trường hợp thêm không thành công nếu cần
                // Ví dụ: ViewData["ErrorMessage"] = "Thêm không thành công";
                return Page();
            }
        }
    }
}
