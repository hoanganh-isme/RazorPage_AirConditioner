using AirConditionerBussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerDAO
{
    public class AirConditionersDAO
    {
        private readonly AirConditionerShopContext _db = null;
        private static AirConditionersDAO instance = null;

        public static AirConditionersDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AirConditionersDAO();
                }
                return instance;
            }
        }

        public AirConditionersDAO()
        {
            _db = new AirConditionerShopContext();
        }

        public List<AirConditioner> GetAllAirConditioner()
        {
            return _db.AirConditioners.Include(p => p.Supplier).ToList();
        }

        public async Task<bool> AddAirConditioner(AirConditioner airConditioner)
        {
            bool result = false;
            try
            {
                _db.Add(airConditioner);
                await _db.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
        public List<AirConditioner> GetAirConditionersByName(string name)
        {
            return _db.AirConditioners.Where(m => m.AirConditionerName.Contains(name)).ToList();
        }
        public AirConditioner GetAirConditionerById(int id)
        {
            return _db.AirConditioners.FirstOrDefault(m => m.AirConditionerId.Equals(id));
        }
        public async Task<AirConditioner> GetAirConditionerByIdAsync(int id)
        {
            return _db.AirConditioners.FirstOrDefault(m => m.AirConditionerId.Equals(id));
        }
        public async Task<AirConditioner> GetAirConditionerByIdNoTracking(int id)
        {
            return await _db.AirConditioners.AsNoTracking().FirstOrDefaultAsync(m => m.AirConditionerId.Equals(id));
        }
        public bool DeleteAirConditioner(int id)
        {
            bool result = false;
            AirConditioner deleteAir = GetAirConditionerById(id);
            try
            {
                _db.Remove(deleteAir);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
        public List<AirConditioner> SearchByName(string name)
        {
            return _db.AirConditioners.Where(p => p.AirConditionerName.Contains(name)).ToList();
        }
        public async Task<bool> EditAirConditioner(int id, AirConditioner airConditioner)
        {
            bool result = false;
            try
            {
                _db.Attach(airConditioner);
                _db.Entry(airConditioner).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            return result;
        }

        public IEnumerable<SupplierCompany> GetSupplierCompanies() => _db.SupplierCompanies.ToList();

    }
}
