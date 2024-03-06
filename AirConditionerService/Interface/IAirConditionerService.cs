using AirConditionerBussinessObjects.Models;
using AirConditionerService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerService.Interface
{
    public interface IAirConditionerService
    {
        public List<AirConditioner> GetAllAirConditioners();
        public Task<bool> AddAirConditioner(AddAirConditionerViewModel airConditionerVM);
        public AirConditioner GetAirConditionerById(int id);
        public Task<AirConditioner> GetAirConditionerByIdAsync(int id);
        public Task<AirConditioner> GetAirConditionerByIdNoTracking(int id);
        public bool DeleteAirConditioner(int id);
        public  Task<bool> EditAirConditioner(int id, EditAirConditionerViewModel airConditionerVM);
        public IEnumerable<SupplierCompany> GetSupplierCompanies();
        public List<AirConditioner> GetAirConditionersByName(string name);
        public List<AirConditioner> SearchByName(string name);
    }
}
