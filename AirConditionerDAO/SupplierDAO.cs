using AirConditionerBussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerDAO
{
    public class SupplierDAO
    {
        private readonly AirConditionerShopContext _db = null;
        private static SupplierDAO instance = null;

        public static SupplierDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SupplierDAO();
                }
                return instance;
            }
        }
        public SupplierDAO()
        {
            _db = new AirConditionerShopContext();
        }
        public List<SupplierCompany> GetAllSuppliers()
        {
            return _db.SupplierCompanies.ToList();
        }

        public async Task<bool> AddSupplier(SupplierCompany supplier)
        {
            bool result = false;
            try
            {
                _db.Add(supplier);
                await _db.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
        public SupplierCompany GetSupplierById(string id)
        {
            return _db.SupplierCompanies.FirstOrDefault(m => m.SupplierId.Equals(id));
        }
        public bool DeleteSupplier(string id)
        {
            bool result = false;
            SupplierCompany deleteSupplier = GetSupplierById(id);
            try
            {
                _db.Remove(deleteSupplier);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
        public bool UpdateSupplier(SupplierCompany supplier)
        {
            bool result = false;
            SupplierCompany staffSupplier = GetSupplierById(supplier.SupplierId);
            if (staffSupplier != null)
            {
                staffSupplier.SupplierId = supplier.SupplierId;
                staffSupplier.SupplierName = supplier.SupplierName;
                staffSupplier.SupplierDescription = supplier.SupplierDescription;
                staffSupplier.PlaceOfOrigin = supplier.PlaceOfOrigin;
                _db.SaveChanges();
                result = true;

            }
            return result;

        }

    }
}
