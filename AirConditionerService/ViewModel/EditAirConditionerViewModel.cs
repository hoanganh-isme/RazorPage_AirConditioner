using AirConditionerBussinessObjects.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerService.ViewModel
{
    public class EditAirConditionerViewModel
    {
        public EditAirConditionerViewModel()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int AirConditionerId { get; set; }
        public string AirConditionerName { get; set; } = null!;
        public string? Warranty { get; set; }
        public string? SoundPressureLevel { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public string? FeatureFunction { get; set; }
        public int? Quantity { get; set; }
        public double? DollarPrice { get; set; }
        public string? SupplierId { get; set; }

        public virtual SupplierCompany? Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
