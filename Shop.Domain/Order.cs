using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain
{
    public class Order : Entity
    {
        public int OrderPrice { get; set; }
        public string Description { get; set; }
        public string OrderStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public string Address { get; set; }
    }
}
