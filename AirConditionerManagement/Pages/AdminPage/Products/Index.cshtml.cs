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
    public class IndexModel : PageModel
    {
        private readonly IAirConditionerService _airConditionerService;

        public IndexModel(IAirConditionerService airConditionerService)
        {
            _airConditionerService = airConditionerService;
        }

        public IList<AirConditioner> AirConditioner { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(string searchKeyword)
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    AirConditioner = _airConditionerService.SearchByName(searchKeyword);
                }
                else
                {
                    AirConditioner = _airConditionerService.GetAllAirConditioners();
                }
                return Page();
            }
            
            return RedirectToPage("/Login");
        }
    }
}
