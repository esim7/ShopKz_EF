using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shop.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Shop.Services
{
    public class Connection : IConnect
    {
        public string connectionString;

        public Connection()
        {
            connectionString = "Server=DESKTOP-RM1NBDJ;Database=ShopDb;Trusted_Connection=True;";
        }
    }
}
