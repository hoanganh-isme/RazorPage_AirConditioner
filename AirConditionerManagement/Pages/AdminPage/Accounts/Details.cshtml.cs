using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirConditionerBussinessObjects.Models;
using AirConditionerRepository;
using AirConditionerService.Interface;

namespace AirConditionerManagement.Pages.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly IStaffMemberService _staffMemberService;


        public DetailsModel(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
        }

        public StaffMember StaffMember { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("Role") == 1) { 
                if (id == null || _staffMemberService.GetAllMembers() == null)
                {
                    return NotFound();
                }

            var staffmember = _staffMemberService.GetMemberById(id);
            if (staffmember == null)
            {
                return NotFound();
            }
            else
            {
                StaffMember = staffmember;
            }
            return Page();
        }
            return RedirectToPage("/Login");
        }

    }
}
