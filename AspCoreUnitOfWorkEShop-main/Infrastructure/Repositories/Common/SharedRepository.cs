using Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using System.Security.Claims;

namespace Infrastructure.Repositories
{
    public class SharedRepository: ISharedRepository
    {        
        
        public readonly IHttpContextAccessor _HttpContextAccessor;       

        public readonly SignInManager<AppUser> _SignInManager;
        public readonly RoleManager<AppRole> _RoleManager;
        public readonly UserManager<AppUser> _UserManager;

        public SharedRepository(
            SignInManager<AppUser> signInManager, 
            RoleManager<AppRole> roleManager, 
            UserManager<AppUser> userManager, 
            IHttpContextAccessor httpContextAccessor
            )
        {
            _SignInManager = signInManager;
            _RoleManager = roleManager;
            _UserManager = userManager;
            _HttpContextAccessor = httpContextAccessor;
        }

        public IHttpContextAccessor _httpContextAccessor()
        {
            return _HttpContextAccessor;
        }

        public SignInManager<AppUser> _signInManager()
        {
            return _SignInManager;
        }

        public RoleManager<AppRole> _roleManager()
        {
            return _RoleManager;
        }

        public UserManager<AppUser> _userManager()
        {
            return _UserManager;
        }
    }
}
