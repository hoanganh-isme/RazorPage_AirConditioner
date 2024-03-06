using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirConditionerBussinessObjects.Models;
using AirConditionerService.Interface;
using CloudinaryDotNet;

namespace AirConditionerManagement.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly IStaffMemberService _staffMemberService;

        public IndexModel(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
        }

        public IList<StaffMember> StaffMember { get;set; } = default!;

        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                if (_staffMemberService.GetAllMembers() != null)
                {
                    StaffMember = _staffMemberService.GetAllMembers();
                }
                return Page();
            }
            return RedirectToPage("/Login");
            
        }
    }
}
