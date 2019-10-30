using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain
{
    public class ShopBasket : Entity
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public int ItemCount { get; set; }
    }
}
