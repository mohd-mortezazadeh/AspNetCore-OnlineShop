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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly IMapper _mapper;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public OrderRepository(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task CreateAsync(OrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            order.Id = Guid.NewGuid();
            order.RegisterDate = DateTime.Now;
            await AddAsync(order);

            foreach (var item in dto.Payload.Split(','))
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                var orderProduct = new OrderProduct()
                {
                    OrderId = order.Id,
                    ProductId = Guid.Parse(item)
                };
                _context.OrderProduct.Add(orderProduct);
            }
            _context.SaveChanges();

            string sessionName = EnumAppSession.ProductCardItems.ToString();
            _httpContextAccessor.HttpContext.Session.Remove(sessionName);
        }

        public void DeleteOrder(OrderDto dto)
        {
            var Order = _mapper.Map<Order>(dto);
            Remove(Order);
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var Order = await GetByIdAsync(id);
            Remove(Order);
        }

        public async Task<OrderDto> GetOrderById(Guid id)
        {
            var Order = await GetByIdAsync(id);
            return _mapper.Map<OrderDto>(Order);
        }

        public async Task<List<OrderDto>> GetOrderListAsync()
        {
            var categories = await GetAllAsync();
            return _mapper.Map<List<OrderDto>>(categories);
        }

        public void Update(Guid id, OrderDto dto)
        {
            var Order = _mapper.Map<Order>(dto);
            Update(Order);
        }

        public IEnumerable<OrderVm> ListVM(IEnumerable<Order> listSelected, OrderReadVm search = null)
        {
            if (search != null)
            {
            }

            var listItemsUser = _context.Users;

            var model = from order in listSelected
                        join user in listItemsUser on order.CreatorUserId equals user.Id
                        select new OrderVm()
                        {
                            Order = order,
                            User = user
                        };


            return model;
        }

        public OrderVm MapEntityToVm(Order modelItem)
        {
            return _mapper.Map<OrderVm>(modelItem);
        }

        public OrderDto MapVmToDto(OrderVm modelVm)
        {
            return _mapper.Map<OrderDto>(modelVm);
        }

        public async Task<bool> IsAvailable(OrderDto dto)
        {
            if (dto.Id!=Guid.Empty)
            {
                var modelItemAvail = await GetAllAsync(s => s.Id != dto.Id && s.Code == dto.Code);
                return modelItemAvail.Count() == 0 ? false : true;
            }
            else
            {
                var modelItemAvail = await GetAllAsync(s => s.Code == dto.Code);
                return modelItemAvail.Count() == 0 ? false : true;
            }
        }
    }
}
