using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatweer_eCommerceTask.Core.Entities;
using Tatweer_eCommerceTask.Core.Specifications;

namespace Tatweer_eCommerceTask.Core.Repositories.Contract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Specs);
        Task<T> GetEntityWithSpecAsync(ISpecification<T> Specs);

        Task<int> GetCountWithSpecAsync(ISpecification<T> Specs);

        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
