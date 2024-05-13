using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatweer_eCommerceTask.Core.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public string UserId { get; set; }
        public ICollection<ShoppingCartItem> Items { get; set; }
    }
}
