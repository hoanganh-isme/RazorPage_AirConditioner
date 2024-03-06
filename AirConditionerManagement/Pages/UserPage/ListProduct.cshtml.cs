using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirConditionerBussinessObjects.Models;
using AirConditionerService.Interface;

namespace AirConditionerManagement.Pages.UserPage
{
    public class ListProductModel : PageModel
    {
        private readonly IAirConditionerService _airConditionerService;

        public ListProductModel(IAirConditionerService airConditionerService)
        {
            _airConditionerService = airConditionerService;
        }

        public IList<AirConditioner> AirConditioner { get;set; } = default!;

        public async Task OnGetAsync()
        {
            
                AirConditioner =  _airConditionerService.GetAllAirConditioners();
            
        }
    }
}
