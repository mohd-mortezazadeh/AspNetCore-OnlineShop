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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public ProductRepository(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task CreateAsync(ProductDto dto)
        {            
            var Product = _mapper.Map<Product>(dto);
            Product.Id = Guid.NewGuid();
                        
            await AddAsync(Product);
        }

        public void DeleteProduct(ProductDto dto)
        {
            var Product = _mapper.Map<Product>(dto);
            Remove(Product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var Product = await GetByIdAsync(id);
            Remove(Product);
        }

        public async Task<ProductDto> GetProductById(Guid id)
        {
            var Product = await GetByIdAsync(id);
            return _mapper.Map<ProductDto>(Product);
        }

        public async Task<List<ProductDto>> GetProductListAsync()
        {
            var categories = await GetAllAsync();
            return _mapper.Map<List<ProductDto>>(categories);
        }

        public void Update(Guid id, ProductDto dto)
        {
            var Product = _mapper.Map<Product>(dto);
            Update(Product);
        }

        public IEnumerable<ProductVm> ListVM(IEnumerable<Product> listSelected, ProductReadVm search = null)
        {
            if (search != null)
            {
            }

            var model = (from product in listSelected
                         select new ProductVm() {
                             Product= product
                         }).ToList();

            return model;
        }

        public ProductVm MapEntityToVm(Product modelItem)
        {
            return _mapper.Map<ProductVm>(modelItem);
        }

        public ProductDto MapVmToDto(ProductVm modelVm)
        {
            return _mapper.Map<ProductDto>(modelVm);
        }

        public async Task<ProductReadDto> ProductCard()
        {
            string sessionname = EnumAppSession.ProductCardItems.ToString();
            string payload=_httpContextAccessor.HttpContext.Session.GetString(sessionname);

            var model = new ProductReadDto();

            if (!string.IsNullOrEmpty(payload))
            {
                foreach (var item in payload.Split(','))
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    var productItem = await GetByIdAsync(Guid.Parse(item.Replace("\"", "")));
                    model.Products.Add(productItem);
                }

                model.ProductsPrice = model.Products.Sum(s => s.Price);
            }

            return model;
        }

        public string AddToCard(string payload)
        {
            string sessionname = EnumAppSession.ProductCardItems.ToString();
            string currentPayload = _httpContextAccessor.HttpContext.Session.GetString(sessionname);

            currentPayload += payload + ",";

            _httpContextAccessor.HttpContext.Session.SetString(sessionname, currentPayload);

            return currentPayload;
        }

        public string DeleteFromCard(string payload)
        {
            string sessionName = EnumAppSession.ProductCardItems.ToString();
            string currentPayload = _httpContextAccessor.HttpContext.Session.GetString(sessionName);

            var productIds = currentPayload.Split(",").ToList();
            var productDeleted = productIds.FirstOrDefault(s => s == payload);
            productIds.Remove(productDeleted);
            _httpContextAccessor.HttpContext.Session.Remove(sessionName);

            foreach (var item in productIds)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                AddToCard(item);
            }

            return currentPayload;
        }
    }
}
