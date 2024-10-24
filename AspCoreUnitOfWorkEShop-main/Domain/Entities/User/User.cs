using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppUser:IdentityUser 
    {        
        public string FullName { get; set; }
        public string Code { get; set; }
        public string MobileNumber { get; set; }
        public string NationalCode { get; set; }
        public string DateBirth { get; set; }
        public bool Gender { get; set; }
        public string Symbol { get; set; }
        public string UserCreatorId { get; set; }
        public string FileAvatar { get; set; }
        public string FileSignature { get; set; }
        public bool IsEnable { get; set; }
        public DateTime DateRegister { get; set; }
        public EnumRoleMain UserType { get; set; }
        public UserStatusEnum Status { get; set; }
    }
}
