using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatweer_eCommerceTask.Core.Entities;
using Tatweer_eCommerceTask.Core.Repositories.Contract;
using Tatweer_eCommerceTask.Repository.Data;

namespace Tatweer_eCommerceTask.Repository
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(StoreContext dbContext) : base(dbContext)
        {
        }

        public async Task AddItemAsync(ShoppingCart cart, ShoppingCartItem item)
        {
            cart.Items.Add(item);
            await UpdateAsync(cart);
        }

        public async Task DeleteItemAsync(ShoppingCart cart, ShoppingCartItem item)
        {
            cart.Items.Remove(item);
            await UpdateAsync(cart);
        }

        public async Task<ShoppingCart> GetAsync(string userId)
        {
            //return await GetAllWithSpecAsync(new ShoppingCartWithItemsSpecification(userId)).FirstOrDefaultAsync();
            throw new NotImplementedException();
        }

        public async Task AddAsync(ShoppingCart cart)
        {
            await AddAsync(cart);
        }

        public async Task UpdateAsync(ShoppingCart cart)
        {
            await UpdateAsync(cart);
        }

        public async Task DeleteAsync(ShoppingCart cart)
        {
            Delete(cart);
            await SaveChangesAsync();
        }

        public Task UpdateItemAsync(ShoppingCart cart, ShoppingCartItem item)
        {
            throw new NotImplementedException();
        }
    }
}
