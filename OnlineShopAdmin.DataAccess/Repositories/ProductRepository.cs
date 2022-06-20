using OnlineShopAdmin.Domain.Models;
using OnlineShopAdmin.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineShopAdmin.DataAccess.DbContexts;

namespace OnlineShopAdmin.DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase<Product> , IProductRepository
    {
        public ProductRepository(AdventureWorksLT2019Context adventureWorksLT2019Context) 
            :base( adventureWorksLT2019Context)           
        {

        }
        
    }
}
