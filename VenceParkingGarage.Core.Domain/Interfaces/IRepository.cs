using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VenceParkingGarage.Core.Domain.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task SaveChangeAsync();
    }
}
