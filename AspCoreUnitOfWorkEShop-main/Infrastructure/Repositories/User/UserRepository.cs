using Application.Contracts;
using Infrastructure.Database;
using Application.ViewModels;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        protected readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(AppUser user)
        {
            await _context.AddAsync(user);
        }

        public void DeleteUser(AppUser user)
        {
            _context.Remove(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            var User = await _context.Users.FindAsync(id);
            _context.Remove(User);
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public List<AppUser> GetUserList()
        {
            return _context.Users.ToList();
        }

        public void Update(AppUser user)
        {
            _context.Update(user);
        }

        public IEnumerable<UserVm> ListVM(IEnumerable<AppUser> listSelected, UserReadVm search = null)
        {
            if (search != null)
            {
            }

            var model = from item in listSelected
                        select _mapper.Map<UserVm>(item);

            return model;
        }

        public UserVm MapEntityToVm(AppUser modelItem)
        {
            return _mapper.Map<UserVm>(modelItem);
        }

        public UserDto MapVmToDto(UserVm modelVm)
        {
            return _mapper.Map<UserDto>(modelVm);
        }
        public IEnumerable<UserVm> ListVm(IEnumerable<AppUser> listSelected)
        {
            List<UserVm> model = new List<UserVm>();

            foreach (var item in listSelected)
            {
                UserVm modelItem = new UserVm();

                modelItem.Id = item.Id;
                modelItem.FullName = item.FullName;
                modelItem.FileAvatarStr = item.FileAvatar;
                modelItem.UserName = item.UserName;
                modelItem.Code = item.Code;
                modelItem.Symbol = item.Symbol;
                modelItem.DateBirth = item.DateBirth;
                modelItem.Gender = item.Gender;
                modelItem.DateRegister = item.DateRegister;
                modelItem.MobileNumber = item.MobileNumber;
                modelItem.UserType = item.UserType;
                modelItem.Status = item.Status;
                modelItem.StatusStr =Infrastructure.Utils.EnumUtils.GetDescription(item.Status);

                model.Add(modelItem);
            }

            return model;
        }

    }
}
