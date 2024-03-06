using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirConditionerBussinessObjects.Models
{
    public partial class AirConditioner
    {
        public AirConditioner()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int AirConditionerId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Chữ cái đầu của tên phải viết hoa")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 100 characters")]
        public string? AirConditionerName { get; set; } = null!;
        [Required(ErrorMessage = "Warranty is required")]
        public string? Warranty { get; set; } 
        [Required(ErrorMessage = "Sound Pressure Level is required")]
        public string? SoundPressureLevel { get; set; } 
        [Required(ErrorMessage = "Image URL is required")]
        public string? Image { get; set; } 
        [Required(ErrorMessage = "Feature Function is required")]
        public string? FeatureFunction { get; set; } 

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 150, ErrorMessage = "Quantity must be between 1 and 150")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Dollar Price is required")]
        [Range(100, 5000, ErrorMessage = "Dollar Price must be between 100 and 5000")]
        public double? DollarPrice { get; set; }

        [Required(ErrorMessage = "Supplier ID is required")]
        public string? SupplierId { get; set; }

        public virtual SupplierCompany? Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
