using AirConditionerBussinessObjects.Models;
using AirConditionerService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AirConditionerManagement.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IStaffMemberService _staffMemberService;

        public RegisterModel(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
        }

        public IActionResult OnGet()
        {
            return Page();
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
            return RedirectToPage("./Login");
        }
    }
}
