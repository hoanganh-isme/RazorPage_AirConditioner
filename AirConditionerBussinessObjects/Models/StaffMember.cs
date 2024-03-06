using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirConditionerBussinessObjects.Models
{
    public partial class StaffMember
    {
        public StaffMember()
        {
            Orders = new HashSet<Order>();
        }
        
        public int MemberId { get; set; }
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Chữ cái đầu của tên phải viết hoa")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "FullName must be between 5 and 15 characters")]
        public string FullName { get; set; } = null!;
        [Required]
        [EmailAddress(ErrorMessage ="No right format")]
        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        [Range(1, 3, ErrorMessage = "Role must be between 1 and 3.")]
        public int? Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
