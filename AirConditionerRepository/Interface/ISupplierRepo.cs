using AirConditionerBussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerRepository.Interface
{
    public interface ISupplierRepo
    {
        public List<SupplierCompany> GetAllSuppliers();

        public Task<bool> AddSupplier(SupplierCompany supplier);
        public SupplierCompany GetSupplierById(string id);
        public bool DeleteSupplier(string id);
        public bool UpdateSupplier(SupplierCompany supplier);

        }
    }

