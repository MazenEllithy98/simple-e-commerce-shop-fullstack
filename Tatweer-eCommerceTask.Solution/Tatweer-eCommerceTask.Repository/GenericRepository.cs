using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatweer_eCommerceTask.Core.Entities;
using Tatweer_eCommerceTask.Core.Repositories.Contract;
using Tatweer_eCommerceTask.Core.Specifications;
using Tatweer_eCommerceTask.Repository.Data;

namespace Tatweer_eCommerceTask.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;

        public GenericRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(T entity)
        => await _dbContext.Set<T>().AddAsync(entity);

        public void Delete(T entity)
        => _dbContext.Set<T>().Remove(entity);
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Specs)
        {
            return await ApplySpecification(Specs).ToListAsync();
        }

        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> Specs)
        {
            return await ApplySpecification(Specs).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountWithSpecAsync(ISpecification<T> Specs)
        {
            return await ApplySpecification(Specs).CountAsync();
        }

        public void Update(T entity)
        => _dbContext.Set<T>().Update(entity);

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }
        public async Task SaveChangesAsync() { await _dbContext.SaveChangesAsync(); }


    }
}
