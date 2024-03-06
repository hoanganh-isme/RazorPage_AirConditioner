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
    public class StaffMemberService : IStaffMemberService
    {
        private readonly IStaffMemberRepo staffMemberRepo = null;
        public StaffMemberService()
        {
            staffMemberRepo = new StaffMemberRepo();
        }

        public bool AddMember(StaffMember member)
        {
            return staffMemberRepo.AddMember(member);
        }

        public bool DeleteMember(int id)
        {
            return staffMemberRepo.DeleteMember(id);
        }

        public List<StaffMember> GetAllMembers()
        {
            return staffMemberRepo.GetAllMembers();
        }

        public StaffMember GetMemberByEmail(string email)
        {
            return staffMemberRepo.GetMemberByEmail(email);
        }
        public StaffMember GetMemberByEmailAndPass(string email, string pass)
        {
            return staffMemberRepo.GetMemberByEmailAndPass(email, pass);
        }
        public StaffMember GetMemberById(int id)
        {
            return staffMemberRepo.GetMemberById(id);
        }

        public bool UpdateMember(StaffMember member)
        {
            return staffMemberRepo.UpdateMember(member);
        }
    }
}
