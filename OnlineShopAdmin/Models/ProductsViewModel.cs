using OnlineShopAdmin.Domain.Models;
using System.Collections.Generic;

namespace OnlineShopAdmin.Models
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }

        public List<SalesOrderHeader> LastOrders { get; set; }
    }
}
