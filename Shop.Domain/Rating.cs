using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain
{
    public class Rating : Entity
    {
        public string UserName { get; set; }
        public Guid ItemId { get; set; }
        public int Mark { get; set; }
        public string Comentary { get; set; }
        public Guid UserId { get; set; }
    }
}
