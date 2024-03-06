using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirConditionerBussinessObjects.Models
{
    public partial class SupplierCompany
    {
        public SupplierCompany()
        {
            AirConditioners = new HashSet<AirConditioner>();
        }
        [Required]
        public string SupplierId { get; set; } = null!;
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Chữ cái đầu của tên phải viết hoa")]
        public string SupplierName { get; set; } = null!;
        [Required]
        public string? SupplierDescription { get; set; }
        [Required]
        public string? PlaceOfOrigin { get; set; }

        public virtual ICollection<AirConditioner> AirConditioners { get; set; }
    }
}
