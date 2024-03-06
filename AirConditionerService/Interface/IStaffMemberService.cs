using AirConditionerBussinessObjects.Models;
using AirConditionerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerService.Interface
{
    public interface IStaffMemberService
    {

        public List<StaffMember> GetAllMembers();
        public StaffMember GetMemberById(int id);
        public bool AddMember(StaffMember member);
        public bool DeleteMember(int id);
        public bool UpdateMember(StaffMember member);
        public StaffMember GetMemberByEmail(string email);
        public StaffMember GetMemberByEmailAndPass(string email, string pass);
    }
}
