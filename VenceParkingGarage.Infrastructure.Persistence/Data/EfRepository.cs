using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VenceParkingGarage.Core.Domain.Interfaces;

namespace VenceParkingGarage.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public Task SaveChangeAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
