using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Shop.Services
{
    public class ShowItem
    {
        Connection connect { get; }

        public ShowItem()
        {
            connect = new Connection();
        }

        public List<Item> ShowItems(int pageSize, int pageNumber)
        {
            if (pageNumber < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            using (var context = new Context(connect.connectionString))
            {
                var result = (from item in context.Items select item).Skip(pageNumber * pageSize).Take(pageSize).ToList();
                return result;
            }
        }
    }
}
