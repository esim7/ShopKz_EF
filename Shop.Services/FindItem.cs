using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Services
{
    public class FindItem
    {
        Connection connect { get; }

        public FindItem()
        {
            connect = new Connection();
        }
        /// <summary>
        /// Метод принимающий поиска строки из БД
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public List<Item>FindItems(string itemName, int pageSize, int pageNumber)
        {
            if (pageNumber < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            using (var context = new Context(connect.connectionString))
            {
                var result = (from item in context.Items where item.Name.Contains(itemName) select item).Skip(pageNumber * pageSize).Take(pageSize).ToList();
                return result;
            }
        }
    }
}
