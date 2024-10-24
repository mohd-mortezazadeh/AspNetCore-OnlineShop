using Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UserReadVm
    {
        public UserReadVm()
        {
    
        }
        public string Id { get; set; }
        public int CountLabEmployee { get; set; }
        public int CountLabOwners { get; set; }
        public int CountTotal { get; set; }
        public UserPartialEnum Partial { get; set; }
        public UserVm UserVm { get; set; }
        public List<UserVm> ListUserVm { get; set; }

    }
}
