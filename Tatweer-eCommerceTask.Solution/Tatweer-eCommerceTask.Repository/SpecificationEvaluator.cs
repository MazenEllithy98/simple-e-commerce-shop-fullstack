using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatweer_eCommerceTask.Core.Entities;
using Tatweer_eCommerceTask.Core.Specifications;

namespace Tatweer_eCommerceTask.Repository
{
    public static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> Specs)
        {
            var query = inputQuery;
            if (Specs.Criteria is not null)
            {
                query = query.Where(Specs.Criteria);
            }

            if (Specs.OrderBy is not null)
                query = query.OrderBy(Specs.OrderBy);

            if (Specs.OrderByDescending is not null)
                query = query.OrderByDescending(Specs.OrderByDescending);

            if (Specs.PaginationEnable is true)
            {
                query = query.Skip(Specs.Skip).Take(Specs.Take);
            }
            return query;
        }


    }
}
