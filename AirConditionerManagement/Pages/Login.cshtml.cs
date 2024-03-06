using AirConditionerBussinessObjects.Models;
using AirConditionerService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AirConditionerManagement.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IStaffMemberService _staffMemberService;

        public LoginModel(IStaffMemberService staffMemberService)
        {
            _staffMemberService = staffMemberService;
        }

        [BindProperty]
        public StaffMember StaffMember { get; set; } = default;

        public void OnGet()
        {
        }
        public IActionResult OnPostLogin()
        {
            StaffMember account = _staffMemberService.GetMemberByEmailAndPass(StaffMember.EmailAddress, StaffMember.Password);
            
            if (account == null)    
            {
                ViewData["notification"] = "Email or Password is wrong!";
                return Page();
            } else if (account.Role == 1)
            {
                HttpContext.Session.SetInt32("Role", (int)account.Role);
                HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(account));
                if (HttpContext.Session.GetInt32("Role") == 1)
                {
                    TempData["UserName"] = account.FullName;
                    return RedirectToPage("/AdminPage/Products/Index");
                }
            } else if (account.Role == 3)
            {
                HttpContext.Session.SetInt32("Role", (int)account.Role);
                HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(account));
                if (HttpContext.Session.GetInt32("Role") == 3)
                {
                    TempData["UserName"] = account.FullName;
                    return RedirectToPage("/UserPage/ListProduct");
                }
            }
            return Page();
        }
    }
}
