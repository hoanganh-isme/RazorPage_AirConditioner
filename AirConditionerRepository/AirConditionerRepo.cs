using AirConditionerBussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AirConditionerDAO;
using AirConditionerRepository.Interface;

namespace AirConditionerRepository
{
    public class AirConditionerRepo : IAirConditionerRepo
    {
        public async Task<bool> AddAirConditioner(AirConditioner airConditioner) => await AirConditionersDAO.Instance.AddAirConditioner(airConditioner);

        public bool DeleteAirConditioner(int id) => AirConditionersDAO.Instance.DeleteAirConditioner(id);

        public async Task<bool> EditAirConditioner(int id, AirConditioner airConditioner) => await AirConditionersDAO.Instance.EditAirConditioner(id,airConditioner);

        public AirConditioner GetAirConditionerById(int id)=> AirConditionersDAO.Instance.GetAirConditionerById(id);
        public async Task<AirConditioner> GetAirConditionerByIdAsync(int id) => await AirConditionersDAO.Instance.GetAirConditionerByIdAsync((int)id);
        public async Task<AirConditioner> GetAirConditionerByIdNoTracking(int id) => await AirConditionersDAO.Instance.GetAirConditionerByIdNoTracking(id);
        public List<AirConditioner> GetAllAirConditioners() => AirConditionersDAO.Instance.GetAllAirConditioner();

        public IEnumerable<SupplierCompany> GetSupplierCompanies() => AirConditionersDAO.Instance.GetSupplierCompanies();
        public List<AirConditioner> GetAirConditionersByName(string name) => AirConditionersDAO.Instance.GetAirConditionersByName(name);
        public List<AirConditioner> SearchByName(string name) => AirConditionersDAO.Instance.SearchByName(name);
    }
}
