using AirConditionerBussinessObjects.Models;
using AirConditionerDAO;
using AirConditionerRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerRepository
{
    public class SupplierRepo : ISupplierRepo
    {
        public async Task<bool> AddSupplier(SupplierCompany supplier) => await SupplierDAO.Instance.AddSupplier(supplier);

        public bool DeleteSupplier(string id) => SupplierDAO.Instance.DeleteSupplier(id);

        public List<SupplierCompany> GetAllSuppliers() => SupplierDAO.Instance.GetAllSuppliers();  

        public SupplierCompany GetSupplierById(string id) => SupplierDAO.Instance.GetSupplierById(id);

        public bool UpdateSupplier(SupplierCompany supplier) => SupplierDAO.Instance.UpdateSupplier(supplier);
    }
}
