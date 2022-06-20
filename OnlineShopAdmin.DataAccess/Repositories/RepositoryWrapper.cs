using System;
using System.Collections.Generic;
using System.Text;
using OnlineShopAdmin.DataAccess.DbContexts;
using OnlineShopAdmin.Domain.Contracts;


namespace OnlineShopAdmin.DataAccess.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AdventureWorksLT2019Context _contex;
        private ProductRepository _product;
        private CustomerRepository _customer;
        private SalesOrderHeaderRepository _SalesOrderHeader;



        public IProductRepository Product 
        {
            get 
            {
                if (_product == null)
                {
                    _product  = new ProductRepository(_contex);
                }
                return _product;

            }
        }

        public ICustomerRepository Customer 
        {
            get 
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_contex);
                }
                return _customer;

            }
        }

        public ISalesOrderHeaderRepository SalesOrderHeader
        {
            get
            {
                if (_SalesOrderHeader == null)
                {
                    _SalesOrderHeader = new SalesOrderHeaderRepository(_contex);
                }
                return _SalesOrderHeader;

            }
        }

       

        public RepositoryWrapper(AdventureWorksLT2019Context adventureWorksLT2019Context)
        {
            _contex = adventureWorksLT2019Context;
           
        }
        public void Save()
        {
            _contex.SaveChanges();
        }
    }
}
