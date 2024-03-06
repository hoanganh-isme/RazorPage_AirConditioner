using System;
using System.Collections.Generic;

namespace AirConditionerBussinessObjects.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int AirConditionerId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public virtual AirConditioner AirConditioner { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
