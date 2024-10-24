using Domain.Entities;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUserRepository
    {
        Task CreateAsync(AppUser user);
        void Update(AppUser user);
        Task<AppUser> GetUserById(string id);
        List<AppUser> GetUserList();
        void DeleteUser(AppUser dto);
        Task DeleteUserAsync(string id);
        IEnumerable<UserVm> ListVM(IEnumerable<AppUser> listSelected, UserReadVm search = null);
        UserVm MapEntityToVm(AppUser modelItem);
        UserDto MapVmToDto(UserVm modelIVm);
    }
}
