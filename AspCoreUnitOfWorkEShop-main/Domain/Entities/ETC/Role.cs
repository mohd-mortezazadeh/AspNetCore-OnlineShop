using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppRole:IdentityRole
    {
        public AppRole() : base()
        {

        }
        public AppRole(string roleName):base()
        {

        }
        public int? ParentId { get; set; }
        public string NameFA { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public bool HasChildren { get; set; }
    }
}
