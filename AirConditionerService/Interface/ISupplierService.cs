using AirConditionerBussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerService.Interface
{
    public interface ISupplierService
    {
        public List<SupplierCompany> GetAllSuppliers();

        public Task<bool> AddSupplier(SupplierCompany supplier);
        public SupplierCompany GetSupplierById(string id);
        public bool DeleteSupplier(string id);
        public bool UpdateSupplier(SupplierCompany supplier);
    }
}
