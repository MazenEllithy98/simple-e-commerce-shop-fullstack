﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tatweer_eCommerceTask.Core.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
