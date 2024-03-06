using AirConditionerBussinessObjects.Models;
using AirConditionerRepository;
using AirConditionerRepository.Interface;
using AirConditionerService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerService
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepo _supplierRepo;
        public SupplierService()
        {
             _supplierRepo = new SupplierRepo();
        }
        public async Task<bool> AddSupplier(SupplierCompany supplier)
        {
            return await _supplierRepo.AddSupplier(supplier);
        }

        public bool DeleteSupplier(string id)
        {
            return _supplierRepo.DeleteSupplier(id);
        }

        public List<SupplierCompany> GetAllSuppliers()
        {
            return _supplierRepo.GetAllSuppliers();
        }

        public SupplierCompany GetSupplierById(string id)
        {
            return _supplierRepo.GetSupplierById(id);
        }

        public bool UpdateSupplier(SupplierCompany supplier)
        {
            return _supplierRepo.UpdateSupplier(supplier);
        }
    }
}
