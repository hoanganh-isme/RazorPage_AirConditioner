using AirConditionerBussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerDAO
{
    public class StaffMemberDAO
    {
        private readonly AirConditionerShopContext _db = null;
        private static StaffMemberDAO instance = null;

        public static StaffMemberDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StaffMemberDAO();
                }
                return instance;
            }
        }
        public StaffMemberDAO()
        {
            _db = new AirConditionerShopContext();
        }

        public List<StaffMember> GetAllMembers()
        {
            return _db.StaffMembers.ToList();
        }
        public StaffMember GetMemberById(int id)
        {
            return _db.StaffMembers.FirstOrDefault(m => m.MemberId.Equals(id));
        }
        public StaffMember GetMemberByEmail(string email)
        {
            return _db.StaffMembers.FirstOrDefault(m => m.EmailAddress.Equals(email));
        }
        public StaffMember GetMemberByEmailAndPass(string email,string pass)
        {
            return _db.StaffMembers.FirstOrDefault(m => m.EmailAddress.Equals(email) && m.Password.Equals(pass));
        }
        public bool AddMember(StaffMember member)
        {
            bool result = false;
            StaffMember account = GetMemberByEmail(member.EmailAddress);
            try
            {
                if (account == null)
                {
                    _db.Add(member);
                    _db.SaveChanges();
                    result = true;
                }         
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
        public bool DeleteMember(int id)
        {
            bool result = false;
            StaffMember deleteMember = GetMemberById(id);
            try
            {
                _db.Remove(deleteMember);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
        public bool UpdateMember(StaffMember member)
        {
            bool result = false;
            StaffMember staff = GetMemberById(member.MemberId);
            if(staff != null)
            {
                staff.MemberId = member.MemberId;
                staff.FullName = member.FullName;
                staff.EmailAddress = member.EmailAddress;
                staff.Role = member.Role;
                _db.SaveChanges();
                result = true;

            }
            return result;

        }
    }
}

