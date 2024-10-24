using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();

        public ProductRepository _ProductRepository { get; }
        public OrderRepository _OrderRepository { get; }
        public OrderProductRepository _OrderProductRepository { get; }
        public LocationRepository _LocationRepository { get; }
        public UserRepository _UserRepository { get; }
    }
}
