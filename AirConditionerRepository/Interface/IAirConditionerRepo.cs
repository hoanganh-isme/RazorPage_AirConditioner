using AirConditionerBussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerRepository.Interface
{
    public interface IAirConditionerRepo
    {
        public List<AirConditioner> GetAllAirConditioners();
        public Task<bool> AddAirConditioner(AirConditioner airConditioner);
        public AirConditioner GetAirConditionerById(int id);
        public Task<AirConditioner> GetAirConditionerByIdNoTracking(int id);
        public Task<AirConditioner> GetAirConditionerByIdAsync(int id);
        public bool DeleteAirConditioner(int id);
        public Task<bool> EditAirConditioner(int id, AirConditioner airConditioner);
        public IEnumerable<SupplierCompany> GetSupplierCompanies();
        public List<AirConditioner> GetAirConditionersByName(string name);
        public List<AirConditioner> SearchByName(string name);

    }
}
