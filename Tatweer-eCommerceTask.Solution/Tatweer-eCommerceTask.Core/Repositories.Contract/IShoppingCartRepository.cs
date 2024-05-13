using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatweer_eCommerceTask.Core.Entities;

namespace Tatweer_eCommerceTask.Core.Repositories.Contract
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetAsync(string userId);
        Task AddAsync(ShoppingCart cart);
        Task UpdateAsync(ShoppingCart cart);
        Task DeleteAsync(ShoppingCart cart);
        Task AddItemAsync(ShoppingCart cart, ShoppingCartItem item);
        Task UpdateItemAsync(ShoppingCart cart, ShoppingCartItem item);
        Task DeleteItemAsync(ShoppingCart cart, ShoppingCartItem item);
    }
}
