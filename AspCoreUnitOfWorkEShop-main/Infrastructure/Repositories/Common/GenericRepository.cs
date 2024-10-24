using Microsoft.EntityFrameworkCore;
using Application.Contracts;
using Infrastructure.Database;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        protected readonly DatabaseContext _context;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await Table().AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Table().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await Table().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            //if (!await AnyAsync(x => x.Id == id))
            //    throw new NotFoundException(nameof(T), id);
            return await Table().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public IQueryable<T> Table()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> TableTracking()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AttachRange(entities);
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
