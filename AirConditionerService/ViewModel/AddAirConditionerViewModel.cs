using AirConditionerBussinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerService.ViewModel
{
    public class AddAirConditionerViewModel
    {
        public AddAirConditionerViewModel()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int AirConditionerId { get; set; }
        public string AirConditionerName { get; set; } = null!;
        public string? Warranty { get; set; }
        public string? SoundPressureLevel { get; set; }
        public IFormFile Image { get; set; }
        public string? FeatureFunction { get; set; }
        public int? Quantity { get; set; }
        public double? DollarPrice { get; set; }
        public string? SupplierId { get; set; }


        public virtual SupplierCompany? Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
