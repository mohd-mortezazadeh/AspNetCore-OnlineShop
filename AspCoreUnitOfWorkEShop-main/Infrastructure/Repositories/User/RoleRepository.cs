using Application.Contracts;
using Infrastructure.Database;
using Domain.Enum;
using Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Infrastructure.Repositories
{
    public class RoleRepository 
    {
        private readonly IMapper _mapper;
        public RoleRepository(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
