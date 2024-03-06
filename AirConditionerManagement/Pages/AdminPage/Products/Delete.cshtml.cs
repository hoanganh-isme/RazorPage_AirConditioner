using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirConditionerBussinessObjects.Models;
using AirConditionerService.Interface;

namespace AirConditionerManagement.Pages.AdminPage.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IAirConditionerService _airConditionerService;

        public DeleteModel(IAirConditionerService airConditionerService)
        {
            _airConditionerService = airConditionerService;
        }

        [BindProperty]
      public AirConditioner AirConditioner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                if (id == null || _airConditionerService.GetAllAirConditioners() == null)
                {
                    return NotFound();
                }

                var airconditioner = _airConditionerService.GetAirConditionerById(id);

                if (airconditioner == null)
                {
                    return NotFound();
                }
                else
                {
                    AirConditioner = airconditioner;
                }
                return Page();
            }
            return RedirectToPage("/Login");
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _airConditionerService.GetAllAirConditioners() == null)
            {
                return NotFound();
            }
            var airconditioner =  _airConditionerService.GetAirConditionerById(id);

            if (airconditioner != null)
            {
                AirConditioner = airconditioner;
                _airConditionerService.DeleteAirConditioner(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
