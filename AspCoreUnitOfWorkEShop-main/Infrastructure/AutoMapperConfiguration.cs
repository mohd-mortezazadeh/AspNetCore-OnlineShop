using AutoMapper;
using Domain.Entities;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Order, OrderVm>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderVm, OrderDto>().ReverseMap();

            CreateMap<Product, ProductVm>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductVm, ProductDto>().ReverseMap();

            CreateMap<AppUser, UserVm>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<UserVm, UserDto>().ReverseMap();
        }
    }
}
