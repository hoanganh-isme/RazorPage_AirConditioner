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
    public class StaffMemberRepo : IStaffMemberRepo
    {
        public bool AddMember(StaffMember member) => StaffMemberDAO.Instance.AddMember(member);

        public bool DeleteMember(int id) => StaffMemberDAO.Instance.DeleteMember(id);

        public List<StaffMember> GetAllMembers() => StaffMemberDAO.Instance.GetAllMembers();

        public StaffMember GetMemberByEmail(string email)=> StaffMemberDAO.Instance.GetMemberByEmail(email);
        public StaffMember GetMemberByEmailAndPass(string email, string pass) => StaffMemberDAO.Instance.GetMemberByEmailAndPass(email, pass);

        public StaffMember GetMemberById(int id) => StaffMemberDAO.Instance.GetMemberById(id);

        public bool UpdateMember(StaffMember member) => StaffMemberDAO.Instance.UpdateMember(member);
    }
}
