
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ISharedRepository
    {
        public IHttpContextAccessor _httpContextAccessor();
        public SignInManager<AppUser> _signInManager();
        public RoleManager<AppRole> _roleManager();
        public UserManager<AppUser> _userManager();
    }
}
