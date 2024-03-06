using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirConditionerBussinessObjects.Models;
using AirConditionerRepository;
using AirConditionerService.Interface;

namespace AirConditionerManagement.Pages.Accounts
{
    public class EditModel : PageModel
    {
        private readonly IStaffMemberService _staffMemberService;

        public EditModel(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
        }

        [BindProperty]
        public StaffMember StaffMember { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("Role") == 1)
            {
                if (id == null || _staffMemberService.GetAllMembers() == null)
                {
                    return NotFound();
                }

                var staffmember = _staffMemberService.GetMemberById(id);
                if (staffmember == null)
                {
                    return NotFound();
                }
                StaffMember = staffmember;
                return Page();
            }
            return RedirectToPage("/Login");
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                _staffMemberService.UpdateMember(StaffMember);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffMemberExists(StaffMember.MemberId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StaffMemberExists(int id)
        {
          return (_staffMemberService.GetAllMembers()?.Any(e => e.MemberId == id)).GetValueOrDefault();
        }
    }
}
