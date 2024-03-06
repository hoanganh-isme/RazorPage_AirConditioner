using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AirConditionerBussinessObjects.Models;
using AirConditionerRepository;
using AirConditionerService.Interface;

namespace AirConditionerManagement.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly IStaffMemberService _staffMemberService;

        public CreateModel(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
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
        public StaffMember StaffMember { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _staffMemberService.GetAllMembers() == null || StaffMember == null)
            {
                return Page();
            }
            _staffMemberService.AddMember(StaffMember);           
            return RedirectToPage("./Index");
        }
    }
}
