using Application.Contracts;
using Infrastructure.Database;
using Domain.Enum;
using Application.ViewModels;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories
{
    public class OrderProductRepository : GenericRepository<OrderProduct>, IOrderProductRepository
    {
        private readonly IMapper _mapper;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public OrderProductRepository(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task CreateAsync(OrderProductDto dto)
        {
            var OrderProduct = _mapper.Map<OrderProduct>(dto);
            OrderProduct.Id = Guid.NewGuid();
            OrderProduct.RegisterDate = DateTime.Now;
            await AddAsync(OrderProduct);

            _context.SaveChanges();

            string sessionName = EnumAppSession.ProductCardItems.ToString();
            _httpContextAccessor.HttpContext.Session.Remove(sessionName);
        }

        public void DeleteOrderProduct(OrderProductDto dto)
        {
            var OrderProduct = _mapper.Map<OrderProduct>(dto);
            Remove(OrderProduct);
        }

        public async Task DeleteOrderProductAsync(Guid id)
        {
            var OrderProduct = await GetByIdAsync(id);
            Remove(OrderProduct);
        }

        public async Task<OrderProductDto> GetOrderProductById(Guid id)
        {
            var OrderProduct = await GetByIdAsync(id);
            return _mapper.Map<OrderProductDto>(OrderProduct);
        }

        public async Task<List<OrderProductDto>> GetOrderProductListAsync()
        {
            var categories = await GetAllAsync();
            return _mapper.Map<List<OrderProductDto>>(categories);
        }

        public void Update(Guid id, OrderProductDto dto)
        {
            var OrderProduct = _mapper.Map<OrderProduct>(dto);
            Update(OrderProduct);
        }

        public IEnumerable<OrderProductVm> ListVM(IEnumerable<OrderProduct> listSelected, OrderProductReadVm search = null)
        {
            if (search != null)
            {
            }

            var listItemsProduct = _context.Product;

            var model = from orderProduct in listSelected
                        join product in listItemsProduct on orderProduct.ProductId equals product.Id
                        select new OrderProductVm()
                        {
                            Product = product
                        };


            return model;
        }

        public OrderProductVm MapEntityToVm(OrderProduct modelItem)
        {
            return _mapper.Map<OrderProductVm>(modelItem);
        }

        public OrderProductDto MapVmToDto(OrderProductVm modelVm)
        {
            return _mapper.Map<OrderProductDto>(modelVm);
        }

    }
}
