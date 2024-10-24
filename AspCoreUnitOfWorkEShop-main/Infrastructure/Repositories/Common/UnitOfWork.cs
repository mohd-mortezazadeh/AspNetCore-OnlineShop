//using DAL.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;
        public readonly IMapper _mapper;
        public readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IWebHostEnvironment _environment;
        private IDbContextTransaction _objTran;
        private bool _disposed;
        private string _errorMessage = string.Empty;
                      
        public ProductRepository _ProductRepository { get; private set; }
        public OrderRepository _OrderRepository { get; private set; }
        public OrderProductRepository _OrderProductRepository { get; private set; }

        public LocationRepository _LocationRepository { get; private set; }
        public UserRepository _UserRepository { get; private set; }

        public UnitOfWork(DatabaseContext context, ILoggerFactory loggerFactory, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _ProductRepository = new ProductRepository(_context, _mapper, _httpContextAccessor);

            _OrderRepository = new OrderRepository(_context, _mapper, _httpContextAccessor);
            
            //_LocationRepository = new LocationRepository(_context, _mapper, _environment);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_objTran!=null)
            {
                _objTran.Commit();
            }           
        }

        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
    }
}
